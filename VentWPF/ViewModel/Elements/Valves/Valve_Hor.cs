using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Воздушый клапан горизонтальный
    /// </summary>
    internal class Valve_Hor : Valve
    {

        public Valve_Hor()
        {
            image = "Valves/Valve_Hor.png";
        }

        public override string Name => "Клапан воздушный горизонтальный";

        

        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            nameof(WidthValve),
            nameof(HeightValve),            
        };
    }
}