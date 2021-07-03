using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель жидкостный
    /// </summary>
    internal class Cooler_Water : HasPerformance
    {
        public Cooler_Water()
        {
            Name = "Охладитель жидкостный";
            image = "Coolers/Cooler_Water.png";
            ShowPD = true;
            ShowPR = true;
        }

        [Category(Data)]
        #region Данные

        [DisplayName("t наружного воздуха")]
        public float tOutside { get; set; } = 123;

        [DisplayName("t воздуха на выходе")]
        public float tOut { get; set; } = 18;

        [DisplayName("t теплоносителя начальная")]
        public float tBegin { get; } = 7;

        [DisplayName("t теплоносителя конечная")]
        public float tEnd { get; } = 12;

        [DisplayName("Влажность воздуха")]
        public float humidityOutSide { get; set; } = 42;

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Падение давления расчётное")]
        public override float PressureDrop => (70 / (4 / (((float)Project.VFlow / 3600) / AB)));

        [DisplayName("Мощность охладителя")]
        public float Power => (float)(Project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));

        [DisplayName("Абсолютная влажность воздуха на выходе")]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (Project.PressOut - (humidityOutSide / 100) * pD / 1000));

        [DisplayName("Относительная влажность воздуха на выходе")]
        public float humidityOutOtn => (float)((Project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);

        #endregion Информация

        [Browsable(false)]
        public float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));

        [Browsable(false)]
        private float AB = (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        [Browsable(false)]
        public float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));
    }
}