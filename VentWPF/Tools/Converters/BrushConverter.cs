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

    class MulConverter : IValueConverter
    {
        public double K { get; init; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return value switch
            {
                null => 0,
                int v => K * v,
                uint v => K * v,
                double v => K * v,
                float v => K * v
            };
            





        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }


    public class MarginConverter : IValueConverter
    {
        public int Direction { get; set; } = 0;

        public Thickness Margin { get; set; } = new Thickness(0, 0, 0, 0);

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        { 
            return Direction switch
            {
                0 => new Thickness(Margin.Left+((dynamic)value),Margin.Top,Margin.Right,Margin.Bottom),
                1 => new Thickness(Margin.Left,Margin.Top+((dynamic)value),Margin.Right,Margin.Bottom),
                2 => new Thickness(Margin.Left,Margin.Top,Margin.Right+((dynamic)value),Margin.Bottom),
                3 => new Thickness(Margin.Left,Margin.Top,Margin.Right,Margin.Bottom+((dynamic)value)),
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}