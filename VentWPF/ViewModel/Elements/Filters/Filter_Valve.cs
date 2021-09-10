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
    /// Представление Фильтр клапанный
    /// </summary>
    internal class Filter_Valve : Filter
    {
        public Filter_Valve()
        {
            image = "Filters/Filter_Valve.png";
        }

        public override string Name => "Фильтр клапанный";

        protected override List<string> InfoProperties => new()
        {
            "FC",
            "GeneratedPressureDrop",
        };
    }
}