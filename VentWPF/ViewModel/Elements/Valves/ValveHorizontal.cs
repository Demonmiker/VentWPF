using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using static VentWPF.ViewModel.Strings;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Воздушый клапан горизонтальный
    /// </summary>
    internal class ValveHorizontal : Valve
    {
        public ValveHorizontal()
        {
        }

        public override string Image => ImagePath("Valves/Horizontal");

        public override string Name => "Клапан воздушный горизонтальный";

        public override List<string> InfoProperties => new()
        {
            nameof(WidthValve),
            nameof(HeightValve),
        };
    }
}