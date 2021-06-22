using System.ComponentModel;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Muffler : HasPerformance
    {
        public Muffler()
        {
            Name = "Шумоглушитель";
            image = "Mufflers/Muffler.png";
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