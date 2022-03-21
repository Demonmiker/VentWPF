using System;
using System.Collections.Generic;
using VentWPF.Fans.Nicotra;
using VentWPF.Model.Calculations;
using static VentWPF.ViewModel.Strings;
using PropertyTools.DataAnnotations;
using VentWPF.Model;

namespace VentWPF.ViewModel
{
    internal class FanP : Fan
    {
        public override void UpdateQuery()
        {
            Query = new FanPQuery()
            {
                // TODO: @stigGGGer Никуда не годится такой запрос
                // Данные  должны объявлятся тут а не по умолчанию
                Source = new FanPRequest()
                {
                    Option = 1,
                    InstType = 1,
                    AirDensity = 0,
                    AirTemperature = 24,
                    Height = 1,
                    FlowRate = ProjectInfo.Settings.VFlow,
                    StaticPressure = ProjectInfo.Settings.PFlow,
                    TotalPressure = Calculations.GPD(Project.Grid.InTopRow(this)) + ProjectInfo.Settings.PFlow,
                    Speed = 0,
                    ShaftPower = 0,
                    Efficiency = 0,
                    SoundPowerLevel = 0,
                    PowerCorrection = 0,
                }
            };
        }

        public override Type DeviceType => typeof(FanPData);

        [Category(Data)]
        [FormatString(fm3Ph)]
        [DisplayName("Вольтаж")]
        public SearchType Type { get; set; } = SearchType.Total;

        public override string Image => ImagePath($"FanP/{Direction}");

        public override int Length => 980;

        public override string Name => "Вентилятор улиточный";

        public override List<string> InfoProperties => new()
        {
            "Power",
            "DeviceData.FlowRate",
            "DeviceData.InstallationType",
            "DeviceData.SmallestReqMotor",
            "DeviceData.StaticPressure",
            "DeviceData.TotalPressure",
            "DeviceData.Speed",
            "DeviceData.ShaftPower",
            "DeviceData.Efficiency",
            "DeviceData.SoundPowerLevelOut",
            "DeviceData.SoundPowerLevelIn",
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}