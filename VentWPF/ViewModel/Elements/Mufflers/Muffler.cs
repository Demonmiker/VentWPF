using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс шумоглушитель
    /// </summary>
    internal abstract class Muffler : Element
    {
        public Muffler()
        {
            image = "Mufflers/Muffler.png";
            ShowPR = true;
            ShowPD = true;
        }

        [Category(Data)]
        [DisplayName("Длинна секции")]
        [FormatString(fmm)]
        public SectionLength FC { get; set; }

        protected override float GeneratedPressureDrop => FC switch
        {
            SectionLength.секция500 => 25,
            SectionLength.секция1000 => 55,
            _ => 60,
        };

        public override List<string> InfoProperties => new()
        {
            "FC",
        };
    }
}