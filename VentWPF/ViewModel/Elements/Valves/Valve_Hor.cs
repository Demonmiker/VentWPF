using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{

    class Valve_Hor : HasPerformance
    {
        public Valve_Hor()
        {
            Name = "Воздушный клапан горизонтальный";
            image = "Valves/Valve_Hor.png";
        }

        public override float Performance => 15;
    }
}
