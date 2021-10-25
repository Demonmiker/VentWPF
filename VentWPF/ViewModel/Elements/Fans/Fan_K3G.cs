using System.Collections.Generic;
using VentWPF.Fans.K3G;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class Fan_K3G : Fan
    {
        public Fan_K3G()
        {
            DeviceType = typeof(K3GData);
        }

        public override void UpdateQuery()
        {
            Query = new K3GQuery()
            {
                Source = new K3GRequest()
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

        public override int Length => 980;

        public override string Name => "Вентилятор поточный";

        public override List<string> InfoProperties => new()
        {
            "PressureDropSystem",
            "PressureRaise",
        };
    }
}