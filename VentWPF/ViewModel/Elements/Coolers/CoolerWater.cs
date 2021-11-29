using PropertyChanged;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Представление Охладитель жидкостный
    /// </summary>
    internal class CoolerWater : Cooler
    {
        public override void UpdateQuery()
        {
            DeviceType = typeof(ВодаХолод);
            Query = new DatabaseQuery<ВодаХолод>
            {
                Source = from o in VentContext.Instance.ВодаХолодs select o
            };
        }

        public override int Width => (int)((DeviceData as ВодаХолод)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ВодаХолод)?.ВысотаГабарит ?? 0);

        public override string Image => ImagePath("Coolers/Water");

        public override int Length => 500;

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Охладитель жидкостный {(DeviceData as ВодаХолод)?.Типоряд}";

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

        /// <summary>
        /// Расход теплоносителя
        /// </summary>
        [Category(Info)]
        [Browsable(false)]
        [DisplayName("Расход теплоносителя")]
        [FormatString(MasFr)]
        public float Consumption => (float)(Power * 1000 / (4198 * Math.Abs(TempBegin - TempEnd))) * 3600;

        [DisplayName("Абс. влажность на выходе")]
        [FormatString(f2)]
        public float HumidOutAbs => Calculations.HumidOutAbs(HumidityIn, TempIn, TempOut, TempBegin);//(float)0.6222 * (HumidOutRel / 100) * Calculations.HumidOut(TempOut) / (Project.PressOut - (HumidOutRel / 100) * Calculations.HumidOut(TempOut) / 1000);//(EnthalpyOut - 1.01f * TempOut) / ((float)2501 + (float)1.86 * TempOut) * 1000;

        //TODO Исправить ошибку переполнения стека
        [DisplayName("Отн. влажность на выходе")]
        [FormatString(fper)]
        public float HumidOutRel => Project.PressOut / pD2 / ((float)0.6222 / (HumidOutAbs * 1000 + 1)) / 10; //Project.PressOut / pD2 * 1000 / ((float)0.6222 / (HumidOutAbs * 1000 + 1));

        [Category(Info)]
        [DisplayName("Мощность")]
        [FormatString(fkW)]
        public float Power => (Project.VFlow / 3600f * 1.2f) * (EnthalpyIn - EnthalpyOut);

        [Browsable(false)]
        public virtual float EnthalpyIn => Calculations.Entolpy(HumidityIn, TempIn);

        [Browsable(false)]
        public virtual float EnthalpyOut => Calculations.EntolpyOut(HumidityIn, TempIn, TempOut, TempBegin);
        

        public override List<string> InfoProperties => new()
        {
            "Vflow",
            "TempIn",
            "TempOut",
            "TempBegin",
            "TempEnd",
            "HumidityIn",            
            "HumidOutAbs",
            "HumidOutRel",
            "DeviceData.LВозд",
            "Consumption",
            "Power",
            //"DeviceData.NКвт",
            "DeviceData.Скорость",           
        };
    }
}