using System.Collections.Generic;
using System.IO;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель сотовый
    /// </summary>
    internal class Humid_Cell : Humid
    {
        public Humid_Cell()
        {
            image = "Humidifiers/Humid_Cell.png";
            SchemeImage = Path.GetFullPath("Assets/Images/Humidifiers/SH_Humid_Cell.png");
        }

        public override string Name => "Увлажнитель сотовый";

        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };
    }
}