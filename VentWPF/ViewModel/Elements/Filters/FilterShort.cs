﻿namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий
    /// </summary>
    internal class FilterShort : Filter
    {
        public FilterShort()
        {
        }

        public override string Image => ImagePath("Filters/Short");

        public override int Length => 680;

        public override string Name => "Фильтр клапанный укороченый";
    }
}