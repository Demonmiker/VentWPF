﻿using System.Collections.Generic;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель сотовый
    /// </summary>
    internal class Humid_Cell : Humid
    {
        #region Constructors

        public Humid_Cell()
        {
            image = "Humidifiers/Humid_Cell.png";
        }

        #endregion

        #region Properties

        public override string Name => "Увлажнитель сотовый";

        protected override List<string> InfoProperties => new()
        {
            "AirSoftIn",
            "AirSoftOut",
            "WaterConsumption",
        };

        #endregion
    }
}