using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Клапан воздушный вертикальный
    /// </summary>
    internal class ValveVertical : Valve
    {
        public ValveVertical()
        {
        }
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<Привода>
            {
                Source = from h in VentContext.Instance.Приводаs select h
            };
        }


        public override string Image => ImagePath("Valves/Vertical");

        public override int Length => 125;

        public override string Name => "Воздушный клапан вертикальный";

        public override List<string> InfoProperties => new()
        {            
            "cut",
            "PressureDrop",
            "DisplayData.Stervo",
        };
    }
}