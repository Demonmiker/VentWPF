using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.Tools;
using VentWPF.ViewModel;
using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System.ComponentModel.DataAnnotations;

namespace VentWPF.Fans.K3G
{
    class K3GRequest : BaseViewModel , IRequest<string>
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; } = K3GController.ID;


        public string GetRequest() => JsonSerializer.Serialize(this);
    }


}
