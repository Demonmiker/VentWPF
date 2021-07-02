using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Humid_Cell : HasPerformance
    {
        public Humid_Cell()
        {
            Name = "Увлажнитель сотовый";
            image = "Humidifiers/Humid_Cell.png";
        }

        #region Данные

        [DisplayName("Влажность на входе")]
        public float AirSoftIn { get; set; } = (float)0.000;

        [DisplayName("Влажность на выходе")]
        public float AirSoftOut { get; set; } = (float)0.0015;

        #endregion Данные

        #region Информация

        [DisplayName("Расход воды")]
        public float Qv => (float)(Performance * 1.17 * (((float)AirSoftOut - (float)AirSoftIn)));

        #endregion Информация
    }
}