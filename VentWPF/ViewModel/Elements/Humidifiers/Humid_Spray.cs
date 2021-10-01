using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель форсуночный
    /// </summary>
    internal class Humid_Spray : Humid
    {

        public Humid_Spray()
        {
            image = "Humidifiers/Humid_Spray.png";
        }

        public override string Name => "Увлажнитель форсуночный";

        protected override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };

    }
}