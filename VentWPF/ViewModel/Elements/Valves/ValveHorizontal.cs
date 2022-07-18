using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Воздушый клапан горизонтальный
    /// </summary>
    internal class ValveHorizontal : Valve
    {
               
        public override string Image => ImagePath("Valves/Horizontal");

        public override string Name => $"Воздушный клапан горизонтальный";

        public override List<string> InfoProperties => new()
        {
            "Cut",
            "PressureDrop",
            "DisplayData.Stervo",
        };
    }
}