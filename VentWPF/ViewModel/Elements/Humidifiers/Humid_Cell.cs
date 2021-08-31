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
    internal class Humid_Cell : Humid
    {
        public Humid_Cell()
        {
            image = "Humidifiers/Humid_Cell.png";
        }

        public override string Name => "Увлажнитель сотовый";

        protected override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };
    }
}