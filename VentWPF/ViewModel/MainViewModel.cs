using PropertyTools.DataAnnotations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            CmdWindowClosed = new(OnWindowClosed);
            CmdSave = new Command<string>(ProjectVM.Current.SaveProject);
            CmdLoad = new Command<object>(ProjectVM.Current.LoadProject);
            CmdNew = new Command<object>(ProjectVM.Current.NewProject);
            CmdUpdateReport = new Command<object>(UpdateReport);
            CmdSaveReport = new Command<object>(SaveReport);
            ReportViewer.Document = ReportDocument;
        }



        public FlowDocumentScrollViewer ReportViewer { get; private set; } = new FlowDocumentScrollViewer();

        public FlowDocument ReportDocument { get; init; } = new FlowDocument() {  FontFamily = new FontFamily("Times New Roman") };

        public int DeviceIndex => ProjectVM.Current.Grid.Selected.DeviceIndex;


        public Command<Popup> CmdOpenPopup { get; init; }

        public Command<object> CmdWindowClosed { get; init; }

        public Command<string> CmdSave { get; init; }

        public Command<object> CmdLoad { get; init; }

        public Command<object> CmdNew { get; init; }

        public Command<string> CmdConfig { get; init; }

        public Command<object> CmdUpdateReport { get; init; }

        public Command<object> CmdSaveReport { get; init; }

        public ProjectVM Project { get; set; } = ProjectVM.Current;


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
        }

        public void SaveReport(object _)
        {
            DocX.DocX_Main export = new DocX.DocX_Main();
            export.DocX_Initialization();            
            /*
            var cfd = new SaveFileDialog() { DefaultExt = "rtf", AddExtension = true };
            if(cfd.ShowDialog()==true)
            {
                using FileStream fs = new FileStream(cfd.FileName, FileMode.Create, FileAccess.ReadWrite);
                TextRange textRange = new TextRange(ReportDocument.ContentStart, ReportDocument.ContentEnd);
                textRange.Save(fs, DataFormats.Rtf);
            }*/
        }

        private void OnWindowClosed(object e)
        {
            App.Current.Shutdown();
        }
    }
}