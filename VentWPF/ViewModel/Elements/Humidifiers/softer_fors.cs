using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    class softer_fors : Element
    {
        public softer_fors()
        {
            Name = "Увлажнитель форсуночный";
        }
        [DisplayName("Производительность"), Category(c1), PropertyOrder(1)]
        public float performance => project.VFlow;

        [DisplayName("Влажность на входе"), Category(c1), PropertyOrder(1)]
        public float AirSoftIn { get; set; } = (float)0.000;

        [DisplayName("Влажность на выходе"), Category(c1), PropertyOrder(1)]
        public float AirSoftOut { get; set; } = (float)0.0015;

        [DisplayName("Расход воды"), Category(" Информация"), PropertyOrder(1)]
        public float Qv => (float)(performance * 1.17 * (((float)AirSoftOut - (float)AirSoftIn)));

    }
}