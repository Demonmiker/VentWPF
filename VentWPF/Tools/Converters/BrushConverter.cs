using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace VentWPF.Tools
{
    class BrushConverter : IValueConverter
    {
        public Brush FalseBrush { get; init; }

        public Brush TrueBrush { get; init; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            bool val = value switch
            {
                null => false,
                bool => (bool)value,
                string => (value as string).Length > 0,
                object => (value as object) != null,
            };
            return val ? TrueBrush : FalseBrush;





        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
}