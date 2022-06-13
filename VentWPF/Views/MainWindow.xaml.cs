using pt = PropertyTools.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Globalization;

namespace VentWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
               XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }
}