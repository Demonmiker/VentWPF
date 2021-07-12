using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VentWPF.Fans.FanSelect
{
    class WebRequest : DllRequest
    {
        [JsonPropertyName("SESSION_ID")]
        public string SessionID { get; set; }
    }
}
