using System.Windows;
using System.Windows.Data;

namespace VentWPF.Tools
{
    /// <summary>
    /// Конвертирует Значение и Направление в Margin с соответствующим сдвигом
    /// </summary>
    public class MarginConverter : IValueConverter
    {
        #region Properties

        public int Direction { get; set; } = 0;

        public Thickness Margin { get; set; } = new Thickness(0, 0, 0, 0);

        #endregion

        #region Methods

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => Direction switch
        {
            0 => new Thickness(Margin.Left + ((dynamic)value), Margin.Top, Margin.Right, Margin.Bottom),
            1 => new Thickness(Margin.Left, Margin.Top + ((dynamic)value), Margin.Right, Margin.Bottom),
            2 => new Thickness(Margin.Left, Margin.Top, Margin.Right + ((dynamic)value), Margin.Bottom),
            3 => new Thickness(Margin.Left, Margin.Top, Margin.Right, Margin.Bottom + ((dynamic)value)),
            _ => Margin,
        };

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) 
            => null;

        #endregion
    }
}