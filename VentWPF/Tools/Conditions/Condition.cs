using System;
using System.Globalization;
using System.Windows.Data;

namespace VentWPF.Tools
{
    /// <summary>
    /// Класс накладывающий ограничения на значения
    /// @@warn Убрать и заменить везде напрямую на Predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Condition<T> : IValueConverter
    {
        public Condition(Predicate<T> predicate)
        {
            Predicate = predicate;
        }

        public Predicate<T> Predicate { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}