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
    /// Представление Фильтр секционный
    /// </summary>
    internal class Filter_Section : Filter
    {
        public Filter_Section()
        {
            image = "Filters/Filter_Section.png";
        }

        public override string Name => $"Фильтр секционный";


        protected override List<string> InfoProperties => new()
        {
            "FC",
            "GeneratedPressureDrop",                   
        };
    }
}