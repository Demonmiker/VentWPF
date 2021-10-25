using System;
using System.Globalization;
using System.Windows.Data;

namespace VentWPF.Tools
{
    /// <summary>
    /// Конвертирует число умножая его на заранее заданный коэфицент
    /// </summary>
    internal class MulConverter : IValueConverter
    {
        /// <summary>
        /// Коэфицент для умножения
        /// </summary>
        public double K { get; init; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value switch
            {
                null => 0,
                int v => K * v,
                uint v => K * v,
                double v => K * v,
                float v => K * v,
                _ => throw new ArgumentException("Данный тип неподдерживается"),
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}