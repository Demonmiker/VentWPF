using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.ViewModel;

namespace VentWPF.Fans.K3G
{
    internal class K3GRequest : BaseViewModel, IRequest<string>
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; } = K3GController.ID;

        public string GetRequest() => JsonSerializer.Serialize(this);
    }
}