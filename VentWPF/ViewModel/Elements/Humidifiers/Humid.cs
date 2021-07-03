using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal abstract class Humid : Element
    {
        public Humid()
        {
            Name = "<Увлажнитель>";
            image = "Humidifiers/Humid_Cell.png";
            ShowPR = true;
        }

        [Category(Data)]
        #region Данные
        [SortIndex(-1)]
        [DisplayName("Влажность на входе")]
        [FormatString(f2)]
        public float AirSoftIn { get; set; } = 0.0f;

        [SortIndex(-1)]
        [DisplayName("Влажность на выходе")]
        [FormatString(f2)]
        public float AirSoftOut { get; set; } = 0.0015f;

        #endregion Данные

        [Category(Info)]
        #region Информация

        [SortIndex(-1)]
        [DisplayName("Расход воды")]
        [FormatString(fNull)]
        public float WaterConsumption => (Performance * 1.17f * ((AirSoftOut - AirSoftIn)));

        #endregion Информация
    }
}