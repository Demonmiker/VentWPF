using System;
using System.ComponentModel;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class Heater_Gas : HasPerformance
    {
        private float AB = (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        public Heater_Gas()
        {
            Name = "Нагреватель газовый";
            image = "Heaters/Heater_Gas.png";
        }

        #region Данные

        [DisplayName("Влажность наружного воздуха")]
        [Category(c1), PropertyOrder(6)]
        public float humidityOutSide { get; set; } = Project.Humid;

        [DisplayName("Горелка")]
        [Category(c1), PropertyOrder(7)]
        public TorchType torch { get; set; }

        [DisplayName("t воздуха на выходе")]
        [Category(c1), PropertyOrder(3)]
        public float tOut { get; set; } = 18;

        [DisplayName("t наружного воздуха")]
        [Category(c1), PropertyOrder(2)]
        public float tOutside => Project.temp;

        #endregion Данные

        #region Информация

        [DisplayName("Абсолютная влажность воздуха на выходе")]
        [Category(c2), PropertyOrder(4)]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (Project.PressOut - (humidityOutSide / 100) * pD / 1000));

        [DisplayName("Относительная влажность воздуха на выходе")]
        [Category(c2), PropertyOrder(4)]
        public int humidityOutOtn => (int)((Project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);

        [Browsable(false)]
        public float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));

        [DisplayName("Мощность воздухонагревателя, кВТ")]
        [Category(c2), PropertyOrder(3)]
        public float Power => (float)(Project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));

        [DisplayName("Падение давления расчётное")]
        [Category(c2), PropertyOrder(1)]
        public override float PressureDrop => (70 / (4 / (((float)Project.VFlow / 3600) / AB)));

        #endregion Информация

        [Browsable(false)]
        public float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));
    }
}