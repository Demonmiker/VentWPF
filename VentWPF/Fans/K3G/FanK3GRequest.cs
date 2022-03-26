using VentWPF.ViewModel;
using VentWPF.Model.Calculations;
namespace VentWPF.Fans.K3G
{
    internal class FanK3GRequest : IRequest<string>
    {

        public int Height { get; set; }
        public static ProjectInfoVM Info { get; set; } = ProjectVM.Current?.ProjectInfo;
        public string ID { get; set; }

        public float Volumenstrom { get; set; }

        public InstallationType Installation { get; set; }

        public PressureType Pressure { get; set; }

        public float AirDens { get; set; }

        public float Altitude { get; set; }

        public float AirTemperature { get; set; }

        public float RequiredPressure { get; set; }

        public int V { get; set; }

        public string GetRequest()
        {
            return $"{ID};{(int)Pressure};{(int)Installation};{AirDens};{Altitude};{AirTemperature};{RequiredPressure};{Volumenstrom};{V};";
        }
    }

    internal enum InstallationType
    {
        DIDO,
        FIDO,
        DIFO,
        FIFO,
    }

    internal enum PressureType
    {
        Static,
        Total,
    }
}