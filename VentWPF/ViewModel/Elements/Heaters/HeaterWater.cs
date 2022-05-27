using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VentWPF.Model;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    /// <summary>
    /// Нагреватель водяной
    /// </summary>
    internal class HeaterWater : Heater
    {
        public override void UpdateQuery()
        {
            Query = new DatabaseQuery<ВодаТепло>
            {
                Source = from h in VentContext.Instance.ВодаТеплоs select h
            };
        }

        public override Type DeviceType => typeof(ВодаТепло);

        public override string Image => ImagePath("Heaters/Water");

        public override int Width => (int)((DeviceData as ВодаТепло)?.ШиринаГабарит ?? 0);

        public override int Height => (int)((DeviceData as ВодаТепло)?.ВысотаГабарит ?? 0);

        public override int Length => 400;

        public override string Name => $"Нагреватель жидкостный {(DeviceData as ВодаТепло)?.Типоряд}";

        /// <summary>
        /// Тип теплоносителя
        /// </summary>
        [Category(Data)]
        [DisplayName("Теплоноситель")]
        public CoolantType Coolant { get; set; }
         
        /// <summary>
        /// Температура теплоносителя начальная
        /// </summary>
        [DisplayName("Температура теплоносителя начальная")]
        [FormatString(Strings.fT)]
        public float TempBegin { get; set; } = 95;

        /// <summary>
        /// Температура теплоносителя конечная
        /// </summary>
        [DisplayName("Температура теплоносителя конечная")]
        [FormatString(Strings.fT)]
        public float TempEnd { get; set; } = 70;

        /// <summary>
        /// Расход теплоносителя
        /// </summary>
        [Category(Info)]
        [DisplayName("Расход теплоносителя")]
        [FormatString(MasFr)]
        public float Consumption => Calculations.heaterConsumption(Power, TempBegin, TempEnd);

        /// <summary>
        /// Падение давления теплоносителя
        /// </summary>
        [DisplayName("Падение давления теплоносителя")]
        [FormatString(fkPa)]
        public float CoolantPressureDrop => 12.5f;
        

        public override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "TempBegin",
            "TempEnd",
            "HumidIn",
            "HumidOutRel",            
            "DeviceData.Скорость",

            "PressureDrop",
            "Consumption",
            "Power",
            "Coolant",
            "CoolantPressureDrop",
            "DeviceData.ДПрисоединения",
        };
    }
}