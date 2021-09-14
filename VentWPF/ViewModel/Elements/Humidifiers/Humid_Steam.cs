using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель паровой
    /// </summary>
    internal class Humid_Steam : Humid
    {
        #region Constructors

        public Humid_Steam()
        {
            image = "Humidifiers/Humid_Steam.png";
        }

        #endregion

        #region Properties

        public override string Name => "Увлажнитель паровой";

        protected override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };

        #endregion
    }
}