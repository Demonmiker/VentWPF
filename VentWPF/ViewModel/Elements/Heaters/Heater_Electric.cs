﻿using PropertyTools.DataAnnotations;
using System;

namespace VentWPF.ViewModel
{
    internal class Heater_Electric : HasPerformance
    {
        public Heater_Electric()
        {
            Name = "Нагреватель электрический";
            image = "Heaters/Heater_Electric.png";
        }
        #region Данные
        [DisplayName("t наружного воздуха")]
        [Category(c1), PropertyOrder(2)]
        public float tOutside => project.temp;

        [DisplayName("t воздуха на выходе")]
        [Category(c1), PropertyOrder(3)]
        public float tOut { get; set; } = 18;

        [DisplayName("t теплоносителя начальная")]
        [Category(c1), PropertyOrder(4)]
        public float tBegin { get; } = 95;

        [DisplayName("t теплоносителя конечная")]
        [Category(c1), PropertyOrder(5)]
        public float tEnd { get; } = 70;

        [DisplayName("Влажность наружного воздуха")]
        [Category(c1), PropertyOrder(6)]
        public float humidityOutSide { get; set; } = 85;
        #endregion

        #region Информация
        [DisplayName("Падение давления расчётное")]
        [Category(c2), PropertyOrder(1)]
        public override float PressureDrop => (70 / (4 / (((float)project.VFlow / 3600) / AB)));

        [DisplayName("Мощность воздухонагревателя")]
        [Category(c2), PropertyOrder(2)]
        public float Power => (float)(project.VFlow * (353 / (273.15 + tOut)) / 3600000 * 1009 * Math.Abs(tOutside - tOut));

        [DisplayName("Число ступеней нагрева")]
        [Category(c2), PropertyOrder(3)]
        public int heatSteps { get { return 3; } }

        [DisplayName("Длина калорифера")]
        [Category(c2), PropertyOrder(4)]
        public int lengthKal { get { return 50; } }

        [Browsable(false)]
        public float pD => (float)(Math.Exp((1500.3 + 23.5 * tOutside) / (234 + tOutside)));

        [DisplayName("Абсолютная влажность воздуха на выходе")]
        [Category(c2), PropertyOrder(4)]
        public float humidityOut => (float)((0.6222 * (humidityOutSide / 100) * pD) / (project.PressOut - (humidityOutSide / 100) * pD / 1000));


        [DisplayName("Относительная влажность воздуха на выходе")]
        [Category(c2), PropertyOrder(4)]
        public int humidityOutOtn => (int)((project.PressOut / pD2 * 1000 / (0.6222 / humidityOut * 1000 + 1)) * 100);
        #endregion
        private float AB = (((float)project.With / 1000) * ((float)project.Height / 1000));

        [Browsable(false)]
        public float pD2 => (float)(Math.Exp((1500.3 + 23.5 * tOut) / (234 + tOut)));


    }
}