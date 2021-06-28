using System;
using System.Windows.Data;

namespace VentWPF.Tools
{
    public class Condition<T> : IValueConverter
    {
        public Predicate<T> Predicate { get; set; }

        public Condition(Predicate<T> predicate)
        {
            Predicate = predicate;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => Predicate((T)value);

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => throw new NotImplementedException();
    }
}
