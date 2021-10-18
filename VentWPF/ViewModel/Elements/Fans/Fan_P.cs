using System.Collections.Generic;
using VentWPF.Fans.Nicotra;

namespace VentWPF.ViewModel
{
    internal class Fan_P : Fan
    {
        public Fan_P()
        {
            DeviceType = typeof(NicotraData);
            Query = new NicotraQuery()
            {
                Source = new NicotraRequest()
            };
            Length = 980;
        }

        public override string Name => "Вентилятор улиточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}