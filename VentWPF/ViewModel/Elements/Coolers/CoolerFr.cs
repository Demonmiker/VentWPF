using PropertyChanged;
using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель фреоновый
    /// </summary>
    internal class CoolerFr : Cooler
    {
        public override void UpdateQuery()
        {
            DeviceType = typeof(ФреонХолод);
            Query = new DatabaseQuery<ФреонХолод>
            {
                Source = from o in VentContext.Instance.ФреонХолодs select o
            };
        }

        public override int Width => (int)((DeviceData as ФреонХолод)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ФреонХолод)?.ВысотаГабарит ?? 0);

        public override string Image => ImagePath("Coolers/Fr");

        public override int Length => 500;

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Фреоновый охладитель {(DeviceData as ФреонХолод)?.Типоряд}";

        /// <summary>
        /// Тип Фреона
        /// </summary>
        [Category(Data)]
        [DisplayName("Тип Фреона")]
        public FrType Fr { get; set; }

        /// <summary>
        /// Температура теплоносителя в начале
        /// </summary>
        [Category(Data)]
        [DisplayName("т. теплоносителя нач.")]
        public float TempBegin => 7;

        /// <summary>
        /// Температура теплоносителя в конце
        /// </summary>
        [DisplayName("т. теплоносителя кон.")]
        public float TempEnd => 12;

        [DisplayName("Абс. влажность на выходе")]
        [FormatString(f2)]
        [DependsOn(nameof(TempIn), nameof(TempOut))]
        public float HumidOutAbs => Calculations.HumidOutAbs(HumidityIn, TempIn, TempOut, TempBegin);

        //TODO Исправить ошибку переполнения стека
        [DisplayName("Отн. влажность на выходе")]
        [FormatString(fper)]
        [DependsOn(nameof(TempIn), nameof(TempOut))]
        public float HumidOutRel => ProjectInfo.Settings.PressOut / pD2 / ((float)0.6222 / (HumidOutAbs * 1000 + 1)) / 10;

        [Category(Info)]
        [DisplayName("Мощность")]
        [FormatString(fkW)]
        [DependsOn(nameof(TempIn), nameof(TempOut))]
        public float Power => (ProjectInfo.Settings.VFlow / 3600f * 1.2f) * (EnthalpyIn - EnthalpyOut);

        [Browsable(false)]
        public float EnthalpyIn => Calculations.Entolpy(HumidityIn, TempIn);

        [Browsable(false)]
        public float EnthalpyOut => Calculations.EntolpyOut(HumidityIn, TempIn, TempOut, TempBegin);

        public override List<string> InfoProperties => new()
        {
            "TempIn",
            "TempOut",
            "HumidityIn",
            "Power",
            "HumidOutAbs",
            "HumidOutRel",
            "DeviceData.LВозд",
            "DeviceData.NКвт",
            "DeviceData.Скорость",
            "DeviceData.КолВоКонтуров",
            "DeviceData.ВысотаГабарит",
            "DeviceData.ШиринаГабарит",
            "Fr",
        };
    }
}