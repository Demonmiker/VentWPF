using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.Tools;
using VentWPF.ViewModel;
using PropertyTools.DataAnnotations;
using static VentWPF.ViewModel.Strings;
using System.ComponentModel.DataAnnotations;

namespace VentWPF.FanDLL
{
    class WEBRequest : DLLRequest
    {
        [Category("Запрос")]
        [JsonPropertyName("SESSIONID")]
        public string SESSIONID { get; set; }

        public WEBRequest(DLLRequest dLLRequest) : base()
        {
            Username = dLLRequest.Username;
            Password = dLLRequest.Password;

        }

        public override string ToString() =>
           JsonSerializer.Serialize(this);
    }
}
