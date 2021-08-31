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
    internal class Humid_Steam : Humid
    {
        public Humid_Steam()
        {
            image = "Humidifiers/Humid_Steam.png";
        }

        public override string Name => "Увлажнитель паровой";

        protected override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };
    }
}