using System.Collections.Generic;
using VentWPF.Fans.K3G;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class FanK3G : Fan
    {
        public FanK3G()
        {
<<<<<<< HEAD:VentWPF/ViewModel/Elements/Fans/Fan_K3G.cs
            DeviceType = typeof(K3GData);
        }

        public override void UpdateQuery()
        {
            Query = new K3GQuery()
=======
            DeviceType = typeof(FanK3GData);
            Query = new FanK3GQuery()
>>>>>>> ptb-update:VentWPF/ViewModel/Elements/Fans/FanK3G.cs
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