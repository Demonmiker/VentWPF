using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель паровой
    /// </summary>
    internal class HumidSteam : Humid
    {
        public HumidSteam()
        {
        }

        public override string Image => ImagePath("Humidifiers/Steam");

        public override int Length => 650;

        public override string Name => "Увлажнитель паровой";
    }
}