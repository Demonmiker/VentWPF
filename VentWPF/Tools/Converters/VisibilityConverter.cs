using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VentWPF.Tools
{
    class VisibilityConverter : IValueConverter
    {
        public bool Reverse { get; init; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = value switch
            {
                null => false,
                bool => (bool)value,
                string => (value as string).Length > 0,
                object => (value as object) != null,
            } ^ Reverse;
            return val ? Visibility.Visible : Visibility.Collapsed;
          
            
                
           

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
}