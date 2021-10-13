﻿namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий
    /// </summary>
    internal class Filter_Short : Filter
    {

        public Filter_Short()
        {
            image = "Filters/Filter_Short.png";
            Length = 680;
        }

        public override string Name => "Фильтр клапанный укороченый";

    }
}