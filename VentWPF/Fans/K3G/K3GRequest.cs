using System.Text.Json.Serialization;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{


    internal class K3GRequest : BaseViewModel, IRequest<string>
    {

        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;


        [JsonPropertyName("ID")]
        public string ID { get; set; } = K3GController.ID;

        [JsonPropertyName("Volumenstrom")]
        public float Volumenstrom { get; set; } = Project.VFlow / 3600;

        [JsonPropertyName("DIDO")] //InstallationType(0:DIDO,1:FIDO,2:DIFO,3:FIFO)
        public int DIDO { get; set; } = 0;

        [JsonPropertyName("Pressure")]// 0 = static Pressure 1 = total pressure
        public int Pressure { get; set; } = 0;

        [JsonPropertyName("AirDens")]
        public float AirDens { get; set; } = 1.14f;

        [JsonPropertyName("Altitude")]// The altitude 
        public float Altitude { get; set; } = 0;

        [JsonPropertyName("AirTemperature")]// AirTemperature(°C) 
        public float AirTemperature { get; set; } = 24;

        [JsonPropertyName("RequiredPressure")]// RequiredPressure(Pa)
        public float RequiredPressure { get; set; } = Project.PReserv;

        [JsonPropertyName("V")]// Required Voltage 0 - all
        public int V { get; set; } = 0;

        public string GetRequest() => $"{ID};{Pressure};{DIDO};{AirDens};{Altitude};{RequiredPressure};{AirTemperature};{Volumenstrom};{V};";
    }
}