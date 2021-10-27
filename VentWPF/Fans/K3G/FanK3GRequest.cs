using VentWPF.ViewModel;
using VentWPF.Model.Calculations;
namespace VentWPF.Fans.K3G
{
    internal class FanK3GRequest : IRequest<string>
    {
        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;
        public string ID { get; set; }

        public float Volumenstrom { get; set; } = Project.VFlow / 3600;

        public InstallationType Installation { get; set; } = InstallationType.DIDO;

        public PressureType Pressure { get; set; } = PressureType.Static;

        public float AirDens { get; set; }

        public float Altitude { get; set; }

        public float AirTemperature { get; set; }

        public float RequiredPressure { get; set; } = Calculations.GPD() + Project.PFlow;

        public int V { get; set; } = 0;

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