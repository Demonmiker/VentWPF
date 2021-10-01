﻿namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр клапанный
    /// </summary>
    internal class Filter_Valve : Filter
    {

        public Filter_Valve()
        {
            image = "Filters/Filter_Valve.png";
        }

        public override string Name => "Фильтр клапанный";

    }
}