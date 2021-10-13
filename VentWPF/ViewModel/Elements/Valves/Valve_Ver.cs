using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный вертикальный
    /// </summary>
    internal class Valve_Ver : Valve
    {

        public Valve_Ver()
        {
            image = "Valves/Valve_Ver.png";
            Length = 125;
        }

        public override string Name => "Клапан воздушный вертикальный";

        
        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            nameof(WidthValve),
            nameof(HeightValve),
        };
    }
}