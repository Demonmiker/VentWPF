using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    internal class Heater_Electric : HasPerformance
    {
        private float AB = (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        public Heater_Electric()
        {
            Name = "Нагреватель электрический";
            image = "Heaters/Heater_Electric.png";
        }

        #region Данные

        [DisplayName("Влажность наружного воздуха")]
        public float humidityOutSide { get; set; } = 85;

        [DisplayName("t теплоносителя начальная")]
        public float tBegin { get; } = 95;

        [DisplayName("t теплоносителя конечная")]
        public float tEnd { get; } = 70;

        [DisplayName("t воздуха на выходе")]
        public float tOut { get; set; } = 18;

        [DisplayName("t наружного воздуха")]
        public float tOutside => Project.temp;

        #endregion Данные

        #region Информация

        [DisplayName("Число ступеней нагрева")]
        public int heatSteps { get { return 3; } }

        [DisplayName("Абсолютная влажность воздуха на выходе")]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (Project.PressOut - (humidityOutSide / 100) * pD / 1000));

        [DisplayName("Относительная влажность воздуха на выходе")]
        public int humidityOutOtn => (int)((Project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);

        [DisplayName("Длина калорифера")]
        public int lengthKal { get { return 50; } }

        [Browsable(false)]
        public float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));

        [DisplayName("Мощность воздухонагревателя")]
        public float Power => (float)(Project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));

        [DisplayName("Падение давления расчётное")]
        public override float PressureDrop => (70 / (4 / (((float)Project.VFlow / 3600) / AB)));

        #endregion Информация

        [Browsable(false)]
        public float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));
    }
}