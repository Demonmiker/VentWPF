using System.Collections.Generic;
using VentWPF.Fans.K3G;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class FanK3G : Fan
    {
        public FanK3G()
        {
            DeviceType = typeof(FanK3GData);
            Query = new FanK3GQuery()
            {
                Source = new FanK3GRequest()
                {
                    AirDens = 1.14f,
                    AirTemperature = 24,
                    Altitude = 0,
                    Installation = InstallationType.DIDO,
                    Pressure = PressureType.Static,//чо
                    RequiredPressure = Project.PReserv,
                    V = 0,
                    Volumenstrom = Project.VFlow / 3600.0f,
                }
            };
        }

        public override string Image => ImagePath($"FanK3G/{Direction}");

        public override int Length => 980;

        public override string Name => "Вентилятор поточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}