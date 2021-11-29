using PropertyTools.DataAnnotations;
using System;
using VentWPF.Model.Calculations;
using VentWPF.Tools;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление общий класс охладителя
    /// </summary>
    internal abstract class Cooler : Element
    {
        public Cooler()
        {
            ShowPR = true;
            ShowPD = true;
        }

        protected override float GeneratedPressureDrop => (70f / (4f / ((Project.VFlow / 3600f) / AB)));

        [Category(Data)]
        [DisplayName("Производительность")]
        [Browsable(false)]
        [FormatString(fm3Ph)]
        public float Vflow => Project.VFlow;

        [Category(Data)]
        [SortIndex(-1)]
        [DisplayName("т. на входе")]
        [FormatString(fT)]
        public float TempIn { get; set; } = 30;

        [SortIndex(-1)]
        [DisplayName("т. на выходе")]
        [FormatString(fT)]
        public float TempOut { get; set; } = 18;

        [SortIndex(-1)]
        [DisplayName("Влажность воздуха")]
        [FormatString(f2)]
        [Range(0, 100)]
        public float HumidityIn { get; set; } = 42;

        

        

        [Browsable(false)]
        public virtual float AB => (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        

        [Browsable(false)]
        public virtual float pD2 => Calculations.HumidOut(TempOut);
    }
}