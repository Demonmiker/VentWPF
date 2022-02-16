using System;
using System.Collections.Generic;
using VentWPF.Fans.Nicotra;

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
            };
        }

        public override Type DeviceType => typeof(FanPData);

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