using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр клапанный
    /// </summary>
    internal class Filter_Valve : Filter
    {
        #region Constructors

        public Filter_Valve()
        {
            image = "Filters/Filter_Valve.png";
        }

        #endregion

        #region Properties

        public override string Name => "Фильтр клапанный";

        #endregion
    }
}