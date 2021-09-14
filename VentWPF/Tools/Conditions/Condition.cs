using System;

namespace VentWPF.Tools
{
    /// <summary>
    /// Класс накладывающий ограничения на значения
    /// @@warn Убрать и заменить везде напрямую на Predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Condition<T> : BaseCondition
    {
        #region Constructors

        public Condition(Predicate<T> predicate)
        {
            Predicate = predicate;
        }

        #endregion

        #region Properties

        public Predicate<T> Predicate { get; set; }

        #endregion
    }
}