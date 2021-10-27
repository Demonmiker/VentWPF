using System.Collections.Generic;
using VentWPF.Fans.Nicotra;

namespace VentWPF.ViewModel
{
    internal class FanP : Fan
    {
        public override void UpdateQuery()
        {
            DeviceType = typeof(FanPData);
            Query = new FanPQuery()
            {
                Source = new FanPRequest()
            };
        }

        public override string Image => ImagePath($"FanP/{Direction}");

        public override int Length => 980;

        public override string Name => "Вентилятор улиточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}