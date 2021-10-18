using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;
using VentWPF.Fans;

namespace VentWPF.ViewModel
{
    internal class Fan_C : Fan
    {
        public Fan_C()
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
                    PressureDrop = 500,
                    SearchTolerance = 10,
                    UnitSystem = "m",
                    VFlow = 6000.0,
                    FanType = "ER"
                }
            };
            Length = 980;
        }

        public override string Name => "Вентилятор";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}