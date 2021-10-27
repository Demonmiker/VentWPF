using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pt = PropertyTools.Wpf;
using System.Threading.Tasks;
using System.Windows;

namespace VentWPF
{
    public partial class Events
    {
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