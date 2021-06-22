using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Muffler_Corrector : HasPerformance
    {
        public Muffler_Corrector()
        {
            Name = "Шумоглушитель с выравниванием";
            image = "Mufflers/Muffler_Corrector.png";
        }

        [DisplayName("Длинна секции")]
        [Category(c1), PropertyOrder(7)]
        public Section FC { get; set; }

        [DisplayName("Падение давления")]
        [Category(c2), PropertyOrder(1)]
        public override float PressureDrop
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