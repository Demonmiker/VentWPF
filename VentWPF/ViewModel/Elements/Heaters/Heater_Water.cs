using PropertyTools.DataAnnotations;
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
    internal class Heater_Water : Heater
    {
        public Heater_Water()
        {
            image = "Heaters/Heater_Water.png";
            DeviceType = typeof(ВодаТепло);
            Query = new DatabaseQuery<ВодаТепло>
            {
                Source = from h in VentContext.Instance.ВодаТеплоs select h
            };
            SchemeImage = Path.GetFullPath("Assets/Images/Heaters/SH_Heater_Water.png");
        }

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
        [DisplayName("т. теплоносителя нач.")]
        public float TempBegin { get; set; } = 95;

        /// <summary>
        /// Температура теплоносителя конечная
        /// </summary>
        [DisplayName("т. теплоносителя кон.")]
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
        [DisplayName("Падение давл. теплоносителя")]
        [FormatString(fkPa)]
        public float CoolantPressureDrop => 12.5f;

        public override List<string> InfoProperties => new()
        {
            "Performance",
            "TempIn",
            "TempOut",
            "tBegin",
            "tEnd",
            "HumidIn",
            "HumidOutRel",
            "DeviceData.Скорость",
            "PressureDrop",
            "Consumption",
            "Coolant",
            "CoolantPressureDrop",
        };
    }
}