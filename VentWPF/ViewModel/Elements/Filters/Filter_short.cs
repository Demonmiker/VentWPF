using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;
using PropertyChanged;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий
    /// </summary>
    internal class Filter_Short : Filter
    {
        public Filter_Short()
        {
            image = "Filters/Filter_Short.png";
        }

        public override string Name => "Фильтр клапанный укороченый";

        protected override List<string> InfoProperties => new()
        {
            "FC",
            "GeneratedPressureDrop",
        };
    }
}