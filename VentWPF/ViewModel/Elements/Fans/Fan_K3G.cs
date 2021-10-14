using System.Collections.Generic;
using VentWPF.Fans.K3G;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Fan_K3G : Fan
    {
        public Fan_K3G()
        {
            Query = new FanQuery_K3G()
            {
                Source = new K3GRequest()
                {
                    ID = "123",
                }
            };
            Length = 980;
        }

        public override string Name => "Вентилятор поточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}