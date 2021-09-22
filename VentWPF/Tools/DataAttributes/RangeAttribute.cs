using System;
using da = System.ComponentModel.DataAnnotations;

namespace VentWPF.Tools
{
    /// <summary>
    /// Класс для валидации данных с поддержкой русского языка
    /// Накладывает ограничения на данные находится в отрезке
    /// </summary>
    internal class RangeAttribute : da.RangeAttribute
    {

        public RangeAttribute(double minimum = double.MinValue, double maximum = double.MaxValue)
            : base(minimum, maximum) { }

        public override string FormatErrorMessage(string name) =>
                ((double)Minimum != double.MinValue,
                (double)Maximum != double.MaxValue) switch
                {
                    (true, true) => $"Значение должно быть между {Minimum} и {Maximum}",
                    (true, false) => $"Значение должно больше {Minimum}",
                    (false, true) => $"Значение должно меньше {Maximum}",
                    (false, false) => throw new Exception("Ошибка атрибута отрезка"),
                };

    }
}