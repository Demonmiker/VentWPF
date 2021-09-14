using PropertyChanged;
using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс Фильтр
    /// </summary>
    internal abstract class Filter : Element
    {
        #region Constructors

        public Filter()
        {
            image = "Filters/Filters.png";
            ShowPD = true;
        }

        #endregion

        #region Properties

        protected override List<string> InfoProperties => new()
        {
            "FC",
            "GeneratedPressureDrop",
        };

        #region Данные

        [Category(Data)]
        [DisplayName("Класс очистки")]
        public FilterClassType FC { get; set; }

        #endregion Данные

        #region Информация

        [Category(Info)]
        [DisplayName("Падение давления при загряз. 50%")]
        [FormatString(fkPa)]
        [DependsOn(nameof(FC))]
        protected override float GeneratedPressureDrop => FC switch
        {
            FilterClassType.G4 => 175,
            FilterClassType.F5 => 225,
            FilterClassType.F9 => 275,
            _ => 0
        };

        #endregion Информация

        #endregion
    }
}