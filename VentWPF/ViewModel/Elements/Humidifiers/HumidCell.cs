using System.Collections.Generic;
using System.IO;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Увлажнитель сотовый
    /// </summary>
    internal class HumidCell : Humid
    {
        public HumidCell()
        {
        }

        public override string Image => ImagePath("Humidifiers/Cell");

        public override int Length => 650;

        public override string Name => "Увлажнитель сотовый";
    }
}