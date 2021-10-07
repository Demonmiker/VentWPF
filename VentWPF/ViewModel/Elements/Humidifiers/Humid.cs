using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс увлажнителей
    /// </summary>
    internal abstract class Humid : Element
    {

        public Humid()
        {
            image = "Humidifiers/Humid_Cell.png";
            ShowPR = true;
        }

        /// <summary>
        /// Влажность на входе
        /// </summary>
        [Category(Data)]
        [SortIndex(-1)]
        [DisplayName("Влажность на входе")]
        [FormatString(f2)]
        public float AirSoftIn { get; set; } = 0.0f;

        /// <summary>
        /// Влажность на выходе
        /// </summary>
        [SortIndex(-1)]
        [DisplayName("Влажность на выходе")]
        [FormatString(f2)]
        public float AirSoftOut { get; set; } = 0.0015f;

        /// <summary>
        /// Расход воды
        /// </summary>
        [Category(Info)]
        [SortIndex(-1)]
        [DisplayName("Расход воды")]
        [FormatString(MasFr)]
        public float WaterConsumption => (Performance * 1.17f * ((AirSoftOut - AirSoftIn)));
    }
}