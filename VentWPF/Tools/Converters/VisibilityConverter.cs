using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using VentWPF.Model;

namespace VentWPF.Tools
{
    /// <summary>
    /// Конвертирует [bool,uint,string,object] => Visibility
    /// </summary>
    internal class VisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Параметр позволяющий обратить значения
        /// </summary>
        public bool Reverse { get; init; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value switch
            {
                null => false,
                bool => (bool)value,
                uint => ((uint)value) > 0,
                int => ((int)value) > 0,
                Rows.Двухярусный => true,
                Rows.Одноярусный => false,
                string => (value as string).Length > 0,
                object => (value as object) != null,
            } ^ Reverse ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}