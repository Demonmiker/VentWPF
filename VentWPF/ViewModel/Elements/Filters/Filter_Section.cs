using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр секционный
    /// </summary>
    internal class Filter_Section : Filter
    {
        #region Constructors

        public Filter_Section()
        {
            image = "Filters/Filter_Section.png";
        }

        #endregion

        #region Properties

        public override string Name => $"Фильтр секционный";

        #endregion
    }
}