using System.Collections.Generic;
using VentWPF.Fans.Nicotra;

namespace VentWPF.ViewModel
{
    internal class Fan_P : Fan
    {
        public Fan_P()
        {
        }

        public override void UpdateQuery()
        {
            DeviceType = typeof(NicotraData);
            Query = new NicotraQuery()
            {
                Source = new NicotraRequest()
                {
                    // TODO нужно указать свойства нормально здесь
                }
            };
        }

        public override int Length => 980;

        public override string Name => "Вентилятор улиточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}