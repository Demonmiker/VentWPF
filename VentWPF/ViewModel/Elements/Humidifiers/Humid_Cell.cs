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
        }

        public override string SchemeImage => ImagePath("Humidifiers/SH_Humid_Cell.png");

        public override int Length => 650;

        public override string Name => "Увлажнитель сотовый";
    }
}