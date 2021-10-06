using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{


    internal class K3GRequest : BaseViewModel, IRequest<string>
    {

        public static ProjectInfoVM Project { get; set; } = ProjectVM.Current?.ProjectInfo;
        

        [JsonPropertyName("ID")]
        public string ID { get; set; } = K3GController.ID;

        [JsonPropertyName("PFlow")]
        public float PFlow { get; set; } = Project.PFlow;

        [JsonPropertyName("PFlow")]
        public float Volumenstrom { get; set; } = Project.VFlow / 3600;

        public string GetRequest() => $"{ID};{0};0:DIDO;{0};{1.14};{0};{24};{PFlow};{Volumenstrom};{0};";
    }
}