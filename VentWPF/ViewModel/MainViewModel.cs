using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows;
using VentWPF.Model;
using VentWPF.Tools;
using System.Windows.Data;
using System.Windows.Media;
using Microsoft.Win32;
using System.Linq;
using PropertyTools.Wpf;
using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Windows.Documents;
using PropertyChanged;
using VentWPF.Fans.FanSelect;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        
        public MainViewModel()
        {

            Request= IOManager.LoadAsJson<DllRequest>("req.json");
            TaskManager.Add(() => { var l = VentContext.Instance.ВодаХолодs; });
            InitTable(ProjectInfo.Rows);
            CmdAddElement = new(AddElement);
            CmdAutoColumns = new(AutoColumns);
            CmdOpenPopup = new(OpenPopup);
            CmdWindowClosed = new(OnWindowClosed);
            CmdSave = new(SaveProject);
            CmdLoad = new(LoadProject);
            CmdConfig = new(OpenConfig);
        }

        public ProjectInfoVM ProjectInfo { get; set; } = ProjectInfoVM.Instance;
        public ImageCollection HeaderImages { get; init; } = new ImageCollection();
        public DllRequest Request { get; set; } = new();

        #region Главное Меню
        [DependsOn("SelectedElement")]
        public FlowDocumentReader ElementAsDocument
        {
            get
            {
                var table = new Table();
                if (SelectedElement is not null)
                {
                    TableRowGroup tg = new();
                    foreach (var item in SelectedElement.Rows)
                        tg.Rows.Add(item);
                    table.RowGroups.Add(tg);
                } 
                return new FlowDocumentReader() { Document = new FlowDocument(table), ViewingMode = FlowDocumentReaderViewingMode.Scroll };
            }
        }

        public int DeviceIndex => SelectedElement.DeviceIndex;
        #endregion


        #region Комманды

        #region Объявление
        public Command<Element> CmdAddElement { get; init; }

        public Command<DataGridAutoGeneratingColumnEventArgs> CmdAutoColumns { get; init; }

        public Command<Popup> CmdOpenPopup { get; init; }

        public Command<object> CmdWindowClosed { get; init; }

        public Command<object> CmdSave { get; init; }

        public Command<object> CmdLoad { get; init; }

        public Command<string> CmdConfig { get; init; }
        #endregion

        private void AutoColumns(DataGridAutoGeneratingColumnEventArgs e)
        {
            var header = e.Column.Header.ToString();
            // Получчение имени из тэга
            var atrs = SelectedElement.Query.Result[0].GetType()
                    .GetProperty(header).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (atrs.Length > 0)
                e.Column.Header = (atrs[0] as DisplayNameAttribute).DisplayName ?? e.Column.Header;
            else
            {
                e.Cancel = true;
                return;
            }
            //Получение форматирования из тэга
            var atrs2 = SelectedElement.Query.Result[0] .GetType()
                .GetProperty(header).GetCustomAttributes(typeof(FormatStringAttribute), true);
            if (atrs2.Length > 0 && e.Column is DataGridTextColumn)
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Binding.StringFormat = (atrs2[0] as FormatStringAttribute).FormatString;
            }


            if (SelectedElement.Format == null) return;
            if (SelectedElement.Format.ContainsKey(header))
            {
                var format = SelectedElement.Format[header];
                if (format != null)
                {
                    Style defaultStyle = Application.Current.TryFindResource(typeof(DataGridCell)) as Style;
                    Style style = new(typeof(DataGridCell), defaultStyle);
                    style.Triggers.Add(new DataTrigger()
                    {
                        Binding = new Binding(header) { Converter = format },
                        Value = true,
                        Setters =
                {
                    new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.PaleGreen},
                    new Setter() { Property = DataGridCell.ForegroundProperty, Value = Brushes.DarkGreen},
                }
                    });
                    style.Triggers.Add(new DataTrigger()
                    {
                        Binding = new Binding(header) { Converter = format },
                        Value = false,
                        Setters =
                {
                    new Setter() { Property = DataGridCell.BackgroundProperty, Value = Brushes.Pink},
                    new Setter() { Property = DataGridCell.ForegroundProperty, Value = Brushes.DarkRed},
                }
                    });
                    e.Column.CellStyle = style;
                }    
            }
          
                
          
           


        }

        private void OpenPopup(Popup p)
        {
            p.HorizontalOffset = 1;
            p.IsOpen = true;
        }

        private void AddElement(Element el)
        {
            var ind = SelectedIndex;
            if (SelectedIndex >= 0 && SelectedIndex < Grid.Count)
            {
                Grid[SelectedIndex] = Element.GetInstance(el);
                SelectedIndex = ind;
                Grid[SelectedIndex].SubType = el.SubType;
            }
                
            SelectedIndex = ind;
        }

        private void OnWindowClosed(object e)
        {
            App.Current.Shutdown();
        }

        private void LoadProject(object o)
        {
            var sfd = new OpenFileDialog{ DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            if (sfd.ShowDialog() == true)
            {
                var project = IOManager.LoadAsJson<Project>(sfd.FileName);
                ProjectInfo = project.ProjectInfo;
                Grid = new ObservableCollection<Element>(project.Grid);
            }
        }

        private void SaveProject(object o)
        {
            var sfd = new SaveFileDialog{ FileName = "Проект", DefaultExt = ".prj", Filter = "Projects (.prj)|*.prj" };
            if(sfd.ShowDialog()==true) IOManager.SaveAsJson(new Project(ProjectInfo,Grid.ToList()), sfd.FileName);
        }

        private void OpenConfig(string s)
        {
            var dlg = new PropertyDialog() { Owner = Application.Current.MainWindow };
            dlg.DataContext = Request;
            dlg.Title = "Настройки";
            dlg.PropertyControl.TabVisibility = TabVisibility.Collapsed;
            if (dlg.ShowDialog().Value)
                IOManager.SaveAsJson(Request, "req.json");
            else
                Request = IOManager.LoadAsJson<DllRequest>("req.json");
            
        }

        #endregion Комманды

        #region Таблица со схемой
        /// <summary>
        /// Выбранный элемент в нижней панели
        /// </summary>
        public Element SelectedElement { get; set; }

        /// <summary>
        /// Индекс выбранного элемента в нижней панели
        /// </summary>
        public int SelectedIndex { get; set; } = 0;

        /// <summary>
        /// Лист отвечающий за хранение всех элементов
        /// </summary>
        public ObservableCollection<Element> Grid { get; set; }

        /// <summary>
        /// Инициализирует Нижнюю панель с заданым количеством рядов
        /// </summary>
        /// <param name="rows">Кол-во рядов</param>
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
            SelectedIndex = 0;
        }

        #endregion Таблица со схемой
    }

   
}