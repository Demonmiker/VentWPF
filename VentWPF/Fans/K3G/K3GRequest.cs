using System.Text.Json.Serialization;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class K3GRequest : IRequest<string>
    {
        public string ID { get; set; }

        public float Volumenstrom { get; set; } = 0;

        public InstallationType Installation { get; set; } = InstallationType.DIDO;

        public PressureType Pressure { get; set; } = PressureType.Static;

        public float AirDens { get; set; }

        public float Altitude { get; set; }

        public float AirTemperature { get; set; }

        public float RequiredPressure { get; set; } = 0;

        public int V { get; set; } = 0;

        public string GetRequest() => $"{ID};{(int)Pressure};{(int)Installation};{AirDens};{Altitude};{AirTemperature};{RequiredPressure};{Volumenstrom};{V};";
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