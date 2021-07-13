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
            CmdAddElement = new(Project.Grid.AddElement);
            CmdAutoColumns = new(AutoColumns);
            CmdOpenPopup = new(OpenPopup);
            CmdWindowClosed = new(OnWindowClosed);
            CmdSave = new(Project.SaveProject);
            CmdLoad = new(Project.LoadProject);
            CmdConfig = new(OpenConfig);
        }
       
        public ImageCollection HeaderImages { get; init; } = new ImageCollection();
        public DllRequest Request { get; set; } = new();

        #region Test
        public ObservableCollection<TestS> Test { get; set; } = new ObservableCollection<TestS>
        {
            new(100),new(150),new(200),new(250),new(300) 
        };
        public class TestS : BaseViewModel
        {
            public int Value { get; set; }

            public TestS(int value)
            {
                Value = value;
            }
        }

        [DependsOn("Test")]
        public int TestSum => Test.Sum(x=>x.Value);
        #endregion

        #region Главное Меню
        public FlowDocumentReader ElementAsDocument
        {
            get
            {
                var table = new Table();
                if (Project.Grid.Selected is not null)
                {
                    TableRowGroup tg = new();
                    foreach (var item in Project.Grid.Selected.Rows)
                        tg.Rows.Add(item);
                    table.RowGroups.Add(tg);
                } 
                return new FlowDocumentReader() { Document = new FlowDocument(table), ViewingMode = FlowDocumentReaderViewingMode.Scroll };
            }
        }

        public int DeviceIndex => Project.Grid.Selected.DeviceIndex;
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
            var atrs = Project.Grid.Selected.Query.Result[0].GetType()
                    .GetProperty(header).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (atrs.Length > 0)
                e.Column.Header = (atrs[0] as DisplayNameAttribute).DisplayName ?? e.Column.Header;
            else
            {
                e.Cancel = true;
                return;
            }
            //Получение форматирования из тэга
            var atrs2 = Project.Grid.Selected.Query.Result[0] .GetType()
                .GetProperty(header).GetCustomAttributes(typeof(FormatStringAttribute), true);
            if (atrs2.Length > 0 && e.Column is DataGridTextColumn)
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Binding.StringFormat = (atrs2[0] as FormatStringAttribute).FormatString;
            }


            if (Project.Grid.Selected.Format == null) return;
            if (Project.Grid.Selected.Format.ContainsKey(header))
            {
                var format = Project.Grid.Selected.Format[header];
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

        private void OnWindowClosed(object e)
        {
            App.Current.Shutdown();
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

        public ProjectVM Project  { get; set; } = ProjectVM.Current;

        #endregion Таблица со схемой
    }

   
}