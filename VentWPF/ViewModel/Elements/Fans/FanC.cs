﻿using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;
using VentWPF.Fans;
using VentWPF.Model.Calculations;
using PropertyChanged;

namespace VentWPF.ViewModel
{
    internal class FanC : Fan
    {
        public override void UpdateQuery()
        {
            DeviceType = typeof(FanCData);
            Query = new FanCQuery()
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

        public override int Width => (int)((DeviceData as FanCData)?.INSTALLATION_WIDTH_MM ?? 0);

        public override int Height => (int)((DeviceData as FanCData)?.INSTALLATION_HEIGHT_MM ?? 0);

        public override int Length => (int)((DeviceData as FanCData)?.INSTALLATION_LENGTH_MM ?? 0);

        [DependsOn(nameof(DeviceData))]
        public override string Name => $"Вентилятор {(DeviceData as FanCData)?.ARTICLE_NO}";

        public override string Image => ImagePath($"FanC/{Direction}");

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}