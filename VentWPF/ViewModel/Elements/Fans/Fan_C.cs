using System.Collections.Generic;
using VentWPF.Fans.FanSelect;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Fan_C : Fan
    {
        public Fan_C()
        {
            Query = new FanQuery_C()
            {
                Source = new DllRequest()
                {
                    PressureDrop = 123,
                }
            };
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