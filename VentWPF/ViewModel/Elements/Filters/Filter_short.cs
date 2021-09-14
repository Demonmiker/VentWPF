using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий
    /// </summary>
    internal class Filter_Short : Filter
    {
        #region Constructors

        public Filter_Short()
        {
            image = "Filters/Filter_Short.png";
        }

        #endregion

        #region Properties

        public override string Name => "Фильтр клапанный укороченый";

        #endregion
    }
}