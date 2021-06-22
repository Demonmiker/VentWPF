using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий
    /// </summary>
    class Filter_Short : HasDownPressure
    {
        public Filter_Short()
        {
            Name = "Фильтр клапанный укороченый";
            image = "Filters/Filter_Short.png";
        }
                

        [DisplayName("Класс очистки"), Category(c1), PropertyOrder(7)]
        public FilterClassType FC { get; set; }

        [DisplayName("Падение давления при загряз. 50%"), Category(c2), PropertyOrder(1)]
        public override float pressureDrop
        {
            get
            {
                if (FC == FilterClassType.G4)
                    return (float)175;
                if (FC == FilterClassType.F5)
                    return (float)225;
                else
                    return (float)275;

            }
        }
    }
}
