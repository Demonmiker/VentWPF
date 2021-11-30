using System.Collections.Generic;
using VentWPF.Fans.K3G;
using PropertyTools.DataAnnotations;

namespace VentWPF.ViewModel
{
    internal class FanK3G : Fan
    {
        public override void UpdateQuery()
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
            "DeviceData.Type",
            "DeviceData.RotateNom",
            "DeviceData.nSoll",
            "DeviceData.IPower",
            "DeviceData.P1Soll",
            "DeviceData.CurrentDraw",
            "DeviceData.ISoll",
            "DeviceData.EtaSoll",
            "DeviceData.MdSoll",
            "DeviceData.EtaMSoll",
            "DeviceData.LwASoll",
            "DeviceData.SPF",
            "DeviceData.LwAssSoll",
            "DeviceData.LwAdsSoll",
            "DeviceData.PtotSoll",
        };
    }
}