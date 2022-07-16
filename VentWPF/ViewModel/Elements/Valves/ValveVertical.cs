﻿using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;
using System;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный вертикальный
    /// </summary>
    internal class ValveVertical : Valve
    {
        
        public override string Image => ImagePath("Valves/Vertical");

        public override int Length => 125;

        public override string Name => "Воздушный клапан вертикальный";

        public override List<string> InfoProperties => new()
        {
            "Cut",
            "PressureDrop",
            "DisplayData.Stervo",
        };
    }
}