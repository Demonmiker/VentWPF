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
        public Filter()
        {
            ShowPD = true;
        }

        public override int Width => 500;

        public override int Height => 600;

        [Category(Data)]
        [DisplayName("Класс очистки")]
        public FilterClassType FC { get; set; }

        public override List<string> InfoProperties => new()
        {
            "FC",
            "GeneratedPressureDrop",
        };

        protected override float GenPD() => FC switch
        {
            FilterClassType.G4 => 175,
            FilterClassType.F5 => 225,
            FilterClassType.F9 => 275,
            _ => 0
        };

        [DependsOn(nameof(FC))]
        [Category(Info)]
        [DisplayName("Падение давления при загряз. 50%")]
        [FormatString(fkPa)]
        public override float PressureDrop { get => base.PressureDrop; set => base.PressureDrop = value; }
    }
}