﻿using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Humid_Spray : HasPerformance
    {
        public Humid_Spray()
        {
            Name = "Увлажнитель форсуночный";
            image = "Humidifiers/Humid_Spray.png";
        }

        #region Данные

        [DisplayName("Влажность на входе")]
        [Category(c1), PropertyOrder(1)]
        public float AirSoftIn { get; set; } = (float)0.000;

        [DisplayName("Влажность на выходе")]
        [Category(c1), PropertyOrder(1)]
        public float AirSoftOut { get; set; } = (float)0.0015;

        #endregion Данные

        #region Информация

        [DisplayName("Расход воды")]
        [Category(c2), PropertyOrder(1)]
        public float Qv => (float)(Performance * 1.17 * (((float)AirSoftOut - (float)AirSoftIn)));

        #endregion Информация
    }
}