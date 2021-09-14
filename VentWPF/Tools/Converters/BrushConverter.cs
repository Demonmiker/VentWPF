using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace VentWPF.Tools
{
    /// <summary>
    /// Конвертор [bool,string,null] -> Brush
    /// </summary>
    internal class BrushConverter : IValueConverter
    {
        #region Properties

        /// <summary>
        /// Значение кисти которое будет использоватся при false
        /// </summary>
        public Brush FalseBrush { get; init; }

        /// <summary>
        /// Значение кисти которое будет использоватся при true
        /// </summary>
        public Brush TrueBrush { get; init; }

        #endregion

        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value switch
        {
            null => false,
            bool => (bool)value,
            string => (value as string).Length > 0,
            _ => (value as object) != null,
        } ? TrueBrush : FalseBrush;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        #endregion
    }
}