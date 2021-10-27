using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;
using VentWPF.Fans;
using VentWPF.Model.Calculations;

namespace VentWPF.ViewModel
{
    internal class FanC : Fan
    {
        public FanC()
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
                    Voltage = 230,
                    VFlow = Project.VFlow,
                    FanType = "ER"
                }
            };
        }

        public override string Image => ImagePath($"FanC/{Direction}");

        public override int Length => 980;

        public override int Width => (int)((DeviceData as FanCData)?.INSTALLATION_WIDTH_MM ?? 0);

        public override int Height => (int)((DeviceData as FanCData)?.INSTALLATION_HEIGHT_MM ?? 0);

        public override string Name => "Вентилятор";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}