using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель паровой
    /// </summary>
    internal class Humid_Steam : Humid
    {

        public Humid_Steam()
        {
            image = "Humidifiers/Humid_Steam.png";
        }

        public override string Name => "Увлажнитель паровой";

        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };

    }
}