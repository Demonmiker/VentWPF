﻿using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;
using VentWPF.Fans;
using VentWPF.Model.Calculations;

namespace VentWPF.ViewModel
{
    internal class Fan_C : Fan
    {
        public override void UpdateQuery()
        {
            DeviceType = typeof(FanCData);
            Query = new FanQuery_C()
            {
                Source = new FanCRequest()
                {
                    InsertGeoData = true,
                    InsertMotorData = true,
                    InsertNominalValues = true,
                    Language = "RU",
                    Password = "bnexg5",
                    Username = "ZAFS19946",
                    InstHeight = Project.Height,
                    InstWidth = Project.Width,
                    PressureDrop = Calculations.GPD() + Project.PFlow,
                    SearchTolerance = 10,
                    UnitSystem = "m",
                    Voltage = 230, // TODO Не динамично нельзя будет изменить
                    VFlow = Project.VFlow,
                    FanType = "ER"
                }
            };
        }

        public override int Length => 980;

        public override string Name => "Вентилятор";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}