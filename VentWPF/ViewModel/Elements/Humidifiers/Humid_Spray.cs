using System.Collections.Generic;
using PropertyTools.DataAnnotations;

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
            Length = 650;
        }

        public override string Name => "Увлажнитель форсуночный";
    }
}