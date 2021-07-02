using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр клапанный
    /// </summary>
    internal class Filter_Valve : Element
    {
        public Filter_Valve()
        {
            Name = "Фильтр клапанный";
            image = "Filters/Filter_Valve.png";
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