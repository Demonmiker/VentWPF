using PropertyTools.DataAnnotations;
using System;
using static VentWPF.ViewModel.Strings;
using valid = VentWPF.Tools;
using VentWPF.Model.Calculations;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Общий класс Нагреватель
    /// </summary>
    internal abstract class Heater : Element
    {
        public Heater()
        {
            ShowPR = true;
            ShowPD = true;
        }

        /// <summary>
        /// Температура на выходе
        /// </summary>
        [Category(Data)]
        [SortIndex(-1)]
        [DisplayName("Температура воздуха на выходе")]
        [FormatString(fT)]
        public float TempOut { get; set; } = 18;

        /// <summary>
        /// Температура на входе
        /// </summary>
        [SortIndex(-1)]
        [DisplayName("Температура наружного воздуха")]
        [FormatString(fT)]
        public float TempIn => ProjectInfo.Settings.Temp;

        /// <summary>
        /// Влажность воздуха на входе
        /// </summary>
        [SortIndex(-1)]
        [DisplayName("Влажность наружнего воздуха")]
        [FormatString(fper)]
        [valid.Range(0, 100)]
        public float HumidIn { get; set; } = 85;

        /// <summary>
        /// Абсолютная влажность воздуха на выходе
        /// </summary>
        [Category(Info)]
        [DisplayName("Абс. влажность на выходе")]
        [FormatString(f2)]
        public float HumidOutAbs => Calculations.heaterHumidOutAbs(HumidIn, TempIn);

        /// <summary>
        /// Относительная алвжность воздуха на выходе
        /// </summary>
        [DisplayName("Влажность воздуха на выходе")]
        [FormatString(fper)]
        public float HumidOutRel => Calculations.heaterHumidOutRel(TempOut, HumidOutAbs);

        /// <summary>
        /// Мощность
        /// </summary>
        [DisplayName("Мощность")]
        [FormatString(fkW)]
        public float Power => Calculations.heaterPower(TempOut, TempIn);

        protected override float GenPD() => 70f / (4f / (ProjectInfo.Settings.VFlow / 3600f / AB));

        [Browsable(false)]
        protected float AB => (ProjectInfo.Settings.Width / 1000f) * (ProjectInfo.Settings.GetHeight(this) / 1000f);

        [Browsable(false)]
        protected float pD2 => (float)Math.Exp((1500.3 + 23.5 * TempOut) / (234 + TempOut));

        [Browsable(false)]
        protected float pD => (float)Math.Exp((1500.3 + 23.5 * TempIn) / (234 + TempIn));
    }
}