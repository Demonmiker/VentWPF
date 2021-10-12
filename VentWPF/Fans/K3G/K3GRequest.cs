using System.Text.Json.Serialization;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class K3GRequest : IRequest<string>
    {
        public string ID { get; set; } // K3GController.ID;

        public float Volumenstrom { get; set; } = 0; // Project.VFlow / 3600;

        public InstallationType Installation { get; set; } = InstallationType.DIDO; //InstallationType(0:DIDO,1:FIDO,2:DIFO,3:FIFO)

        public PressureType Pressure { get; set; } = PressureType.Static;  // 0 = static Pressure 1 = total pressure

        public float AirDens { get; set; } = 1.14f;

        public float Altitude { get; set; } = 0;

        public float AirTemperature { get; set; } = 24;

        public float RequiredPressure { get; set; } = 0; //Project.PReserv;

        public int V { get; set; } = 0;

        public string GetRequest() => $"{ID};{(int)Pressure};{(int)Installation};{AirDens};{Altitude};{RequiredPressure};{AirTemperature};{Volumenstrom};{V};";
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