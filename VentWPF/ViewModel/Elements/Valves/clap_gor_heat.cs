using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    class clap_gor_heat : HasDownPressure
    {
        public clap_gor_heat()
        {
            Name = "Воздушный клапан горизонтальный с нагревателем";
        }
        [DisplayName("Производительность"), Category(c1), PropertyOrder(1)]
        public float performance => project.VFlow;

        [DisplayName("Падение давления"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop => 15;

        [DisplayName("Количество ТЭНов"), Category(c1), PropertyOrder(2)]
        public float TEN_count { get; set; } = 3;

    }
}

