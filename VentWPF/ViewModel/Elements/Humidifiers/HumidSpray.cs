using System.Collections.Generic;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель форсуночный
    /// </summary>
    internal class HumidSpray : Humid
    {
        public HumidSpray()
        {
        }

        public override string Image => ImagePath("Humidifiers/Spray");

        public override int Length => 1500;

        public override string Name => "Увлажнитель форсуночный";
    }
}