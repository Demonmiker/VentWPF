using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

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
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<Привода>
            {
                Source = from h in VentContext.Instance.Приводаs select h
            };
        }
        public override string Image => ImagePath("Valves/Horizontal");

        public override string Name => "Воздушный клапан горизонтальный";

        public override List<string> InfoProperties => new()
        {
            "cut",
            "PressureDrop",
            "DisplayData.Stervo",
        };
    }
}