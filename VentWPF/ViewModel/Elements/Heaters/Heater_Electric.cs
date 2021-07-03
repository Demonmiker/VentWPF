using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    internal class Heater_Electric : Heater
    {
        private float AB = (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        public Heater_Electric()
        {
            Name = "Нагреватель электрический";
            image = "Heaters/Heater_Electric.png";
        }

        [Category(Data)]
        #region Данные

        [DisplayName("т. теплоносителя начальная")]
        [FormatString(fT)]
        public float tBegin { get; } = 95;

        [DisplayName("т. теплоносителя конечная")]
        [FormatString(fT)]
        public float tEnd { get; } = 70;

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Ступеней нагрева")]
        public int heatSteps => 3;

        [DisplayName("Длина калорифера")]
        public int lengthKal => 50;

        #endregion Информация

    
    }
}