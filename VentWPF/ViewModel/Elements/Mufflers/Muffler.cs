using PropertyChanged;
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
            ShowPR = true;
            ShowPD = true;
        }

        [Category(Data)]
        [DisplayName("Длинна секции")]
        [FormatString(fmm)]
        public SectionLength SectionLen { get; set; }

        protected override float GenPD() => SectionLen switch
        {
            SectionLength.секция500 => 25,
            SectionLength.секция1000 => 55,
            _ => 60,
        };

        public override List<string> InfoProperties => new()
        {
            nameof(SectionLen),
        };

        [DependsOn(nameof(SectionLen))]
        public override float PressureDrop { get => base.PressureDrop; set => base.PressureDrop = value; }
    }
}