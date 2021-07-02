using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр Короткий
    /// </summary>
    internal class Filter_Short : Element
    {
        public Filter_Short()
        {
            Name = "Фильтр клапанный укороченый";
            image = "Filters/Filter_Short.png";
        }

        #region Данные

        [DisplayName("Класс очистки")]
        public FilterClassType FC { get; set; }

        #endregion Данные

        #region Информация

        [DisplayName("Падение давления при загряз. 50%")]
        public override float PressureDrop => FC switch
        {
            FilterClassType.G4 => 175,
            FilterClassType.F5 => 225,
            FilterClassType.F9 => 275,
            _ => 0
        };

        #endregion Информация
    }
}