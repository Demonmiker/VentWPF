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

        #region Данные

        [DisplayName("Длинна секции")]
        
        public Section FC { get; set; }

        #endregion Данные

        #region Информация

        [DisplayName("Падение давления")]
        
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

        #endregion Информация
    }
}