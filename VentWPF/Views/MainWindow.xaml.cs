using pt = PropertyTools.Wpf;
using System;
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

        private void TbxGotFocus(object sender, RoutedEventArgs e)
        {
            object o = e.OriginalSource;
            if (o is pt.TextBoxEx tb)
            {
                string text = tb.Text;
                int i = text.Length - 1;
                while (i != -1 && !Char.IsDigit(text[i])) i--;
                tb.Text = text[0..(i + 1)];
            }
        }
    }
}