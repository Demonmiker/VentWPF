using System.Collections.Generic;
using VentWPF.Fans.K3G;
using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;

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
                    AirDens = AirDensity, //1.15f,
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


        [Category(Data)]
        [FormatString(fm3Ph)]
        [DisplayName("Плотность воздуха")]
        public float AirDensity => 1.15f;


        public override string Image => ImagePath($"FanK3G/{Direction}");

        public override int Length => 980;

        public override string Name => "Вентилятор поточный";

        public override List<string> InfoProperties => new()
        {
            "DeviceData.Type",
            "Power",
            //"DeviceData.LwASoll",
            "PressureDropSystem",
            "PressureRaise",            
            "DeviceData.RotateNom",
            "DeviceData.nSoll",
            "DeviceData.IPower",
            "DeviceData.P1Soll",
            //"DeviceData.CurrentDraw",
            //"DeviceData.ISoll",
            "DeviceData.EtaSoll",
            //"DeviceData.MdSoll",
            "DeviceData.EtaMSoll",            
            //"DeviceData.SPF",
            //"DeviceData.LwAssSoll",
            //"DeviceData.LwAdsSoll",
            //"DeviceData.PtotSoll",
        };
    }
}