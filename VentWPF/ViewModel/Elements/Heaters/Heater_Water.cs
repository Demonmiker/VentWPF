using PropertyTools.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using static VentWPF.ViewModel.Strings;

namespace VentWPF.ViewModel
{
    internal class Heater_Water : Heater
    {
        #region Constructors

        public Heater_Water()
        {
            image = "Heaters/Heater_Water.png";
            DeviceType = typeof(ВодаТепло);
            Query = new DatabaseQuery<ВодаТепло>
            {
                Source = from h in VentContext.Instance.ВодаТеплоs select h
            };
        }

        #endregion

        #region Properties

        public override string Name => $"Нагреватель жидкостный {(DeviceData as ВодаТепло)?.Типоряд}";

        protected override List<string> InfoProperties => new()
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

        #region Данные


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

        #endregion Данные

        #region Информация

        /// <summary>
        /// Расход теплоносителя
        /// </summary>
        [Category(Info)]
        [DisplayName("Расход теплоносителя")]
        [FormatString(MasFr)]
        public float Consumption => (float)(((Power * 1000) / (4198 * (TempBegin - TempEnd)))) * 3600;

        /// <summary>
        /// Падение давления теплоносителя
        /// </summary>
        [DisplayName("Падение давл. теплоносителя")]
        [FormatString(fkPa)]
        public float CoolantPressureDrop => 12.5f;

        #endregion Информация

        #endregion
    }
}