using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{

    class Valve_Hor_Heat : HasPerformance
    {
        public Valve_Hor_Heat()
        {
            Name = "Воздушный клапан горизонтальный с нагревателем";
            image = "Valves/Valve_Hor_Heat.png";
        }

        [DisplayName("Количество ТЭНов")]
        [Category(c1), PropertyOrder(2)]
        public float TEN_count { get; set; } = 3;

        public override float Performance => 15;
    }
}

