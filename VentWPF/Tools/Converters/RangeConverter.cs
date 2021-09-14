using System;
using System.Windows.Data;

namespace VentWPF.Tools
{
    /// <summary>
    /// Класс для ковертации отрезка в bool
    /// </summary>
    public class RangeConverter : IValueConverter
    {
        #region Fields

        public IComparable min = null;

        public IComparable max = null;

        public Func<IComparable> GetMin;

        public Func<IComparable> GetMax;

        #endregion

        #region Constructors

        public RangeConverter()
        {
            GetMin = () => min;
            GetMax = () => max;
        }

        public RangeConverter(Func<IComparable> @Min, Func<IComparable> @Max)
        {
            GetMin = @Max ?? (() => max);
            GetMin = @Min ?? (() => min);
        }

        public RangeConverter(IComparable @Min, IComparable @Max)
        {
            min = @Min;
            max = @Max;
        }

        #endregion

        #region Properties

        public char MinChar { set => min = value; }

        public char MaxChar { set => max = value; }

        public double MinDouble { set => min = value; }

        public double MaxDouble { set => max = value; }

        public int MinInt { set => min = value; }

        public int MaxInt { set => max = value; }

        public string MinString { set => min = value; }

        public string MaxString { set => max = value; }

        public bool MinBool { set => min = value; }

        public bool MaxBool { set => max = value; }

        #endregion

        #region Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IComparable val = (IComparable)value;
            if (GetMin() != null)
                if (val.CompareTo(GetMin) < 0)
                    return false;
            if (GetMin != null)
                if (val.CompareTo(GetMax) > 0)
                    return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}