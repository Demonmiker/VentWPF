using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows;
using VentWPF.Model;
using VentWPF.Tools;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;
using PropertyTools.Wpf;
using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Windows.Documents;
using PropertyChanged;
using VentWPF.Fans.FanSelect;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Constructors

        public MainViewModel()
        {
            Request = IOManager.LoadAsJson<DllRequest>("req.json");
            ProjectVM.Current?.TaskManager.Add(() => { var l = VentContext.Instance.ВодаХолодs; });
            CmdAddElement = new(ProjectVM.Current.Grid.AddElement);
            CmdAutoColumns = new(AutoColumns);
            CmdOpenPopup = new(OpenPopup);
            CmdWindowClosed = new(OnWindowClosed);
            CmdSave = new(ProjectVM.Current.SaveProject);
            CmdLoad = new(ProjectVM.Current.LoadProject);
            CmdConfig = new(OpenConfig);
        }

        #endregion

        #region Properties

        public ImageCollection HeaderImages { get; init; } = new ImageCollection();

        public DllRequest Request { get; set; } = new();

        #endregion

        #region Главное Меню

        public FlowDocumentReader ElementAsDocument
        {
            get
            {
                return new FlowDocumentReader() { Document = new FlowDocument(ProjectVM.Current.Grid.Selected.GetTable(2)), ViewingMode = FlowDocumentReaderViewingMode.Scroll };
            }
        }

        public int DeviceIndex => ProjectVM.Current.Grid.Selected.DeviceIndex;

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
            var atrs = ProjectVM.Current.Grid.Selected.Query.Result[0].GetType()
                    .GetProperty(header).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (atrs.Length > 0)
                e.Column.Header = (atrs[0] as DisplayNameAttribute).DisplayName ?? e.Column.Header;
            else
            {
                e.Cancel = true;
                return;
            }
            //Получение форматирования из тэга
            var atrs2 = ProjectVM.Current.Grid.Selected.Query.Result[0].GetType()
                .GetProperty(header).GetCustomAttributes(typeof(FormatStringAttribute), true);
            if (atrs2.Length > 0 && e.Column is DataGridTextColumn)
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Binding.StringFormat = (atrs2[0] as FormatStringAttribute).FormatString;
            }

            if (ProjectVM.Current.Grid.Selected.Format == null) return;
            if (ProjectVM.Current.Grid.Selected.Format.ContainsKey(header))
            {
                var format = ProjectVM.Current.Grid.Selected.Format[header];
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

        public ProjectVM Project { get; set; } = ProjectVM.Current;
    }
}