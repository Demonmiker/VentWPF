using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр секционный
    /// </summary>
    internal class Filter_Section : Element
    {
        public Filter_Section()
        {
            Name = "Фильтр секционный";
            image = "Filters/Filter_Section.png";
        }

        [DisplayName("Класс очистки")]
        [Category(c1), PropertyOrder(7)]
        public FilterClassType FC { get; set; }

        [DisplayName("Падение давления при загряз. 50%")]
        [Category(c2), PropertyOrder(1)]
        public override float PressureDrop
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