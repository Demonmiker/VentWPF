using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows;
using VentWPF.Model;
using VentWPF.Tools;
using System.Windows.Data;
using System.Windows.Media;
using VentWPF.FanDLL;
using Microsoft.Win32;
using System.Linq;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        
        public MainViewModel()
        {

            //Request= IOManager.LoadAsJson<DLLRequest>("req.json");
            InitTable(ProjectInfo.Rows);
            CmdAddElement = new(AddElement);
            CmdAutoColumns = new(AutoColumns);
            CmdOpenPopup = new(OpenPopup);
            CmdWindowClosed = new(OnWindowClosed);
            CmdSave = new(Save);
            CmdLoad = new(Load);
        }

        public ProjectInfoVM ProjectInfo { get; set; } = ProjectInfoVM.Instance;
        public ImageCollection HeaderImages { get; init; } = new ImageCollection();
        public DLLRequest Request { get; init; } = new();

        #region Комманды

        public Command<Element> CmdAddElement { get; init; }

        public Command<DataGridAutoGeneratingColumnEventArgs> CmdAutoColumns { get; init; }

        public Command<Popup> CmdOpenPopup { get; init; } 

        public Command<object> CmdWindowClosed { get; init; }

        public Command<object> CmdSave { get; init; }

        public Command<object> CmdLoad { get; init; }

        private void AutoColumns(DataGridAutoGeneratingColumnEventArgs e)
        {
            if (SelectedElement.Format.ContainsKey(e.Column.Header.ToString()))
            {
                Style defaultStyle = Application.Current.TryFindResource(typeof(DataGridCell)) as Style;
                Style style = new Style(typeof(DataGridCell), defaultStyle);
                style.Triggers.Add(new DataTrigger()
                {
                    Binding = new Binding(e.Column.Header.ToString()) { Converter = SelectedElement.Format[e.Column.Header.ToString()].conv },
                    Value = true,
                    Setters =
                {
                    new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.PaleGreen},
                    new Setter() { Property = DataGridCell.ForegroundProperty, Value = Brushes.DarkGreen},
                }
                });
                style.Triggers.Add(new DataTrigger()
                {
                    Binding = new Binding(e.Column.Header.ToString()) { Converter = SelectedElement.Format[e.Column.Header.ToString()].conv },
                    Value = false,
                    Setters =
                {
                    new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.Pink},
                    new Setter() { Property = DataGridCell.ForegroundProperty, Value = Brushes.DarkRed},
                }
                });
                e.Column.Header = SelectedElement.Format[e.Column.Header.ToString()].name;
                e.Column.CellStyle = style;
            }
          
           


        }

        private static void OpenPopup(Popup p)
        {
            p.HorizontalOffset = 1;
            p.IsOpen = true;
        }

        private void AddElement(Element el)
        {
            var ind = SelectedIndex;
            if (SelectedIndex >= 0 && SelectedIndex < Grid.Count)
                Grid[SelectedIndex] = el;
            SelectedIndex = ind;
        }

        private void OnWindowClosed(object e)
        {
            VentContext.Instance.Dispose();
            //IOManager.SaveAsJson(Request, "req.json");
        }

        private void Load(object o)
        {
            OpenFileDialog sfd = new OpenFileDialog() { DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            if (sfd.ShowDialog() == true)
            {
                var project = IOManager.LoadAsJson<Project>(sfd.FileName);
                ProjectInfo = project.ProjectInfo;
                Grid = new ObservableCollection<Element>(project.Grid);
            }
        }

        private void Save(object o)
        {
            SaveFileDialog sfd = new SaveFileDialog() { FileName = "Проект", DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            if(sfd.ShowDialog()==true) IOManager.SaveAsJson(new Project(ProjectInfo,Grid.ToList()), sfd.FileName);
        }
        #endregion Комманды

        #region Таблица со схемой
        public Element SelectedElement { get; set; }
        public int SelectedIndex { get; set; } = 0;
        public ObservableCollection<Element> Grid { get; set; }

        public void InitTable(Rows rows)
        {
            if (rows == Rows.Row1)
            {
                Grid = new ObservableCollection<Element>()
                {
                    new(),new(),new(),new(),new(),new(),new(),new(),new(),new(),
                };
            }
            else
            {
                Grid = new ObservableCollection<Element>()
                {
                    new(),new(),new(),new(),new(),new(),new(),new(),new(),new(),
                    new(),new(),new(),new(),new(),new(),new(),new(),new(),new(),
                };
            }
        }

        #endregion Таблица со схемой
    }
}