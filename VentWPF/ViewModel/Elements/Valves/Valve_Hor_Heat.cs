using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    class Valve_Hor_Heat : HasDownPressure
    {
        public Valve_Hor_Heat()
        {
            Name = "Воздушный клапан горизонтальный с нагревателем";
            image = "Valves/Valve_Hor_Heat.png";
        }
        [DisplayName("Производительность"), Category(c1), PropertyOrder(1)]
        public float performance => project.VFlow;

        [DisplayName("Падение давления"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop => 15;

        [DisplayName("Количество ТЭНов"), Category(c1), PropertyOrder(2)]
        public float TEN_count { get; set; } = 3;

    }
}

