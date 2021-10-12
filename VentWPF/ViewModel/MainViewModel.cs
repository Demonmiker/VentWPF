using PropertyTools.DataAnnotations;
using PropertyTools.Wpf;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VentWPF.Fans.FanSelect;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Request = IOManager.LoadAsJson<DllRequest>("req.json");
            ProjectVM.Current?.TaskManager.Add(() => { Microsoft.EntityFrameworkCore.DbSet<ВодаХолод> l = VentContext.Instance.ВодаХолодs; });
            CmdAddElement = new(ProjectVM.Current.Grid.AddElement);
            CmdAutoColumns = new(AutoColumns);
            CmdOpenPopup = new(OpenPopup);
            CmdWindowClosed = new(OnWindowClosed);
            CmdSave = new(ProjectVM.Current.SaveProject);
            CmdLoad = new(ProjectVM.Current.LoadProject);
            CmdConfig = new(OpenConfig);
            CmdUpdateReport = new Command<object>(UpdateReport);
            CmdSaveReport = new Command<object>(SaveReport);
            ReportViewer.Document = ReportDocument;
        }

        public ImageCollection HeaderImages { get; init; } = new ImageCollection();

        public DllRequest Request { get; set; } = new();

        public FlowDocumentScrollViewer ReportViewer { get; private set; }
            = new FlowDocumentScrollViewer();

        public FlowDocument ReportDocument { get; init; } = new FlowDocument();

        public int DeviceIndex => ProjectVM.Current.Grid.Selected.DeviceIndex;

        public Command<Element> CmdAddElement { get; init; }

        public Command<DataGridAutoGeneratingColumnEventArgs> CmdAutoColumns { get; init; }

        public Command<Popup> CmdOpenPopup { get; init; }

        public Command<object> CmdWindowClosed { get; init; }

        public Command<object> CmdSave { get; init; }

        public Command<object> CmdLoad { get; init; }

        public Command<string> CmdConfig { get; init; }

        public Command<object> CmdUpdateReport { get; init; }

        public Command<object> CmdSaveReport { get; init; }

        public ProjectVM Project { get; set; } = ProjectVM.Current;

        private void AutoColumns(DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            // Получчение имени из тэга
            object[] atrs = ProjectVM.Current.Grid.Selected.Query.Result[0].GetType()
                    .GetProperty(header).GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (atrs.Length > 0)
            {
                e.Column.Header = (atrs[0] as DisplayNameAttribute).DisplayName ?? e.Column.Header;
            }
            else
            {
                e.Cancel = true;
                return;
            }
            //Получение форматирования из тэга
            object[] atrs2 = ProjectVM.Current.Grid.Selected.Query.Result[0].GetType()
                .GetProperty(header).GetCustomAttributes(typeof(FormatStringAttribute), true);
            if (atrs2.Length > 0 && e.Column is DataGridTextColumn)
            {
                DataGridTextColumn col = e.Column as DataGridTextColumn;
                col.Binding.StringFormat = (atrs2[0] as FormatStringAttribute).FormatString;
            }

            if (ProjectVM.Current.Grid.Selected.Format == null)
                return;
            if (ProjectVM.Current.Grid.Selected.Format.ContainsKey(header))
            {
                IValueConverter format = ProjectVM.Current.Grid.Selected.Format[header];
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

        public void UpdateReport(object _)
        {
            ReportDocument.Blocks.Clear();
            foreach (var item in Project.Grid.Elements)
            {
                if (item.Name != "")
                {
                    ReportDocument.Blocks.Add(item.GetTable(2, false));
                    ReportDocument.Blocks.Add(new Paragraph());
                }
            }

            // TODO этого здесь не должно быть
            try
            {
            SaveImage("scheme.png", Project.Elements["scheme"]);
            SaveImage("frame_top.png", Project.Elements["frame_top"]);
            SaveImage("frame_left.png", Project.Elements["frame_left"]);
            SaveImage("frame_right.png", Project.Elements["frame_right"]);

            }
            catch
            {

            }

            //
        }

        public void SaveReport(object _)
        {
            DocX.DocX_Main test = new DocX.DocX_Main();
            test.DocX_Initialization();
            /*
            var cfd = new SaveFileDialog() { DefaultExt = "rtf", AddExtension = true };
            if(cfd.ShowDialog()==true)
            {
                using FileStream fs = new FileStream(cfd.FileName, FileMode.Create, FileAccess.ReadWrite);
                TextRange textRange = new TextRange(ReportDocument.ContentStart, ReportDocument.ContentEnd);
                textRange.Save(fs, DataFormats.Rtf);
            }*/
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
            PropertyDialog dlg = new() { Owner = Application.Current.MainWindow };
            dlg.DataContext = Request;
            dlg.Title = "Настройки";
            dlg.PropertyControl.TabVisibility = TabVisibility.Collapsed;
            if (dlg.ShowDialog().Value)
                IOManager.SaveAsJson(Request, "req.json");
            else
                Request = IOManager.LoadAsJson<DllRequest>("req.json");
        }

        private void SaveImage(string path, FrameworkElement gui)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)gui.ActualWidth + 10, (int)gui.ActualHeight + 10, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(gui);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            FileStream fs = new FileStream(path, FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }
    }
}