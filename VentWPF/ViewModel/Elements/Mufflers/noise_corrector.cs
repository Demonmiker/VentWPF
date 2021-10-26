using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    class noise_corrector : HasDownPressure
    {
        public noise_corrector()
        {
            Name = "Шумоглушитель с выравниванием";
        }
        [DisplayName("Производительность"), Category(c1), PropertyOrder(1)]
        public float performance => project.VFlow;

        [DisplayName("Длинна секции"), Category(c1), PropertyOrder(7)]
        public Section FC { get; set; }

        [DisplayName("Падение давления"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop
        {
            get
            {
                if (FC == Section.секция500)
                    return (float)25;
                if (FC == Section.секция1000)
                    return (float)55;
                else
                    return (float)60;

            }
        }
    }
}
