using System.Collections.Generic;

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

        protected override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };

    }
}