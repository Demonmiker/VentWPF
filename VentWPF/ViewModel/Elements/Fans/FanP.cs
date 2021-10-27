using System.Collections.Generic;
using VentWPF.Fans.Nicotra;

namespace VentWPF.ViewModel
{
    internal class FanP : Fan
    {
        public FanP()
        {
<<<<<<< HEAD:VentWPF/ViewModel/Elements/Fans/Fan_P.cs
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
=======
            DeviceType = typeof(FanPData);
            Query = new FanPQuery()
            {
                Source = new FanPRequest()
>>>>>>> ptb-update:VentWPF/ViewModel/Elements/Fans/FanP.cs
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