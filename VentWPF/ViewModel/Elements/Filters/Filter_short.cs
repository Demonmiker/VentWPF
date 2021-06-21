using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    
    class Filter_Short : HasDownPressure
    {
        public Filter_Short()
        {
            Name = "Фильтр клапанный укороченый";
            image = "Filter_Short.png";
        }
                

        [DisplayName("Класс очистки"), Category(c1), PropertyOrder(7)]
        public FClassType FC { get; set; }

        [DisplayName("Падение давления при загряз. 50%"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop
        {
            get
            {
                if (FC == FClassType.G4)
                    return (float)175;
                if (FC == FClassType.F5)
                    return (float)225;
                else
                    return (float)275;

            }
        }
    }
}
