using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Фильтр секционный
    /// </summary>
    internal abstract class Filter : Element
    {
        public Filter()
        {
            Name = "<Фильтр>";
            image = "Filters/Filters.png";
            ShowPD = true;
        }

        [Category(Data)]
        #region Данные

        [DisplayName("Класс очистки")]
        public FilterClassType FC { get; set; }

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Падение давления при загряз. 50%")]
        [FormatString(fP)]
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