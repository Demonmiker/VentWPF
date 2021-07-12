using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VentWPF.Model;
using VentWPF.Tools;
using PropertyChanged;

namespace VentWPF.ViewModel
{
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
        }

        public override string Name => $"Нагреватель жидкостный {(DeviceData as ВодаТепло)?.Типоряд}";

        protected override List<string> InfoProperties => new ()
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

        

        [Category(Data)]
        #region Данные

        [DisplayName("Теплоноситель")]
        public CoolantType Coolant { get; set; }

        [DisplayName("т. теплоносителя нач.")]
        public float TempBegin { get; set; } = 95;

        [DisplayName("т. теплоносителя кон.")]
        public float TempEnd { get; set; } = 70;

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