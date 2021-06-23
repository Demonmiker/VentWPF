﻿using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр секционный
    /// </summary>
    internal class Filter_Section : Element
    {
        public Filter_Section()
        {
            Name = "Фильтр секционный";
            image = "Filters/Filter_Section.png";
        }

        #region Данные

        [DisplayName("Класс очистки")]
        [Category(c1), PropertyOrder(7)]
        public FilterClassType FC { get; set; }

        #endregion Данные

        #region Информация

        [DisplayName("Падение давления при загряз. 50%")]
        [Category(c2), PropertyOrder(1)]
        public override float PressureDrop => FC switch
        {
            FilterClassType.G4 => 175,
            FilterClassType.F5 => 225,
            FilterClassType.F9 => 275,
            _ => 0
        };

        #endregion Информация
    }
}