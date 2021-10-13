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
                Source = new DllRequest()
                {
                    PressureDrop = 123,
                }
            };
            Length = 980;
        }

        public override string Name => "Вентилятор";

        [Browsable(false)]
        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}