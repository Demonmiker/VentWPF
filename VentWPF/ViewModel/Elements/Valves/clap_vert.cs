using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;
namespace VentWPF.ViewModel
{
    
    class clap_vert : HasDownPressure
    {
        public clap_vert()
        {
            Name = "Воздушный клапан Вертикальный";
        }
        [DisplayName("Производительность"), Category(c1), PropertyOrder(1)]
        public float performance => project.VFlow;

        [DisplayName("Падение давления"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop => 15;


    }
}
