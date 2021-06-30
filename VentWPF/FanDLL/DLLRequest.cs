using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentWPF.Tools;
using VentWPF.ViewModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VentWPF.FanDLL
{
    class DLLRequest : BaseViewModel , ISaveLoad
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = "login";
        [JsonPropertyName("password")]
        public string Password { get; set; } = "password";
        [JsonPropertyName("qv")]
        public double VFlow { get; set; } = 6000;
        [JsonPropertyName("psf")]
        public double PressureDrop { get; set; } = 150;
        [JsonPropertyName("search_tolerance")]
        public double SearchTolerance { get; set; } = 10;
        [JsonPropertyName("language")]
        public string Language { get; set; } = "RU";
        [JsonPropertyName("unit_system")]
        public string UnitSystem { get; set; } = "m";
        [JsonPropertyName("insert_geo_data")]
        public bool InsertGeoData { get; set; } = true;
        [JsonPropertyName("insert_motor_data")]
        public bool insertMotorData { get; set; } = true;
        [JsonPropertyName("insert_nominal_values")]
        public bool InsertNominalValues { get; set; } = true;

        public override string ToString() =>
           JsonSerializer.Serialize(this);


    }

    

}
