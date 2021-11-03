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

        [Category(Info)]
        [DisplayName("Мощность")]
        [FormatString(fkW)]
        public float Power => ((float)(Project.VFlow / 3600 * (float)1.2) * (EnthalpyIn - EnthalpyOut));

        [DisplayName("Абс. влажность на выходе")]
        [FormatString(f2)]
        public float HumidOutAbs => (EnthalpyOut - (float)1.01 * TempOut) / ((float)2501 + (float)1.86 * TempOut) * 1000;

        [DisplayName("Отн. влажность на выходе")]
        [FormatString(fper)]
        public float HumidOutRel => Project.PressOut / pD2 * 1000 / ((float)0.6222 / (HumidOutAbs * 1000 + 1));

        [Browsable(false)]
        public virtual float AB => (((float)Project.Width / 1000) * ((float)Project.Height / 1000));

        [Browsable(true)]
        public virtual float EnthalpyIn => Calculations.Entolpy(HumidOutRel, TempIn);

        [Browsable(true)]
        public virtual float EnthalpyOut => Calculations.Entolpy(HumidOutRel, TempOut);

        [Browsable(true)]
        public virtual float pD2 => Calculations.HumidOut(TempOut);
    }
}