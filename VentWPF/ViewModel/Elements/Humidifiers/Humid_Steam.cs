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

        public override int Length => 650;

        public override string Name => "Увлажнитель паровой";
    }
}