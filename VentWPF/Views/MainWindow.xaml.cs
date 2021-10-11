using System.Windows;
using System.Windows.Controls;

namespace VentWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public DataGrid datagrid => this.dg;
    }
}