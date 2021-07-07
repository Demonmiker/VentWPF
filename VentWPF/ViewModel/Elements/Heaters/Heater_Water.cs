using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;

namespace VentWPF.ViewModel
{
    internal class Heater_Water : Heater
    {
        public Heater_Water()
        {
            Name = "Нагреватель жидкосный";
            image = "Heaters/Heater_Water.png";
            ShowQuery = true;
        }

        protected override List<string> InfoProperties => new ()
        {
            "DeviceData.Типоряд",
            "Performance",
            "TempIn",
            "TempOut",
            "tBegin",
            "tEnd",
            "HumidIn",
            "HumidOutRel",
            //DeviceData.Скорость,
            "PressureDrop",
            "Consumption",
            "Coolant",
            "CoolantPressureDrop",



        };

        public override IList Query => ((IQueryable<object>)(from h in VentContext.Instance.ВодаТеплоs select h)).ToList();

        [Category(Data)]
        #region Данные

        [DisplayName("Теплоноситель")]
        public CoolantType Coolant { get; set; }

        [DisplayName("т. теплоносителя нач.")]
        public float tBegin { get; set; } = 95;

        [DisplayName("т. теплоносителя кон.")]
        public float tEnd { get; set; } = 70;

        #endregion Данные

        [Category(Info)]
        #region Информация

        [DisplayName("Расход теплоносителя")]
        [FormatString(fNull)]
        public float Consumption => (float)(Power * 1000 / (4200 * Math.Abs(TempIn - TempOut)) * 3600);


        [DisplayName("Падение давл. теплоносителя")]
        [FormatString(fP)]
        public float CoolantPressureDrop => 12.5f;

        #endregion Информация

     
    }
}