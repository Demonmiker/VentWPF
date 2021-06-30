using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.Tools;
using VentWPF.ViewModel;

namespace VentWPF.FanDLL
{
    internal class DLLRequest : BaseViewModel
    {
        [JsonPropertyName("insert_geo_data")]
        public bool InsertGeoData { get; set; } = true;

        [JsonPropertyName("insert_motor_data")]
        public bool insertMotorData { get; set; } = true;

        [JsonPropertyName("insert_nominal_values")]
        public bool InsertNominalValues { get; set; } = true;

        [JsonPropertyName("language")]
        public string Language { get; set; } = "RU";

        [JsonPropertyName("password")]
        public string Password { get; set; } = "password";

        [JsonPropertyName("psf")]
        public double PressureDrop { get; set; } = 150;

        [JsonPropertyName("search_tolerance")]
        public double SearchTolerance { get; set; } = 10;

        [JsonPropertyName("unit_system")]
        public string UnitSystem { get; set; } = "m";

        [JsonPropertyName("username")]
        public string Username { get; set; } = "login";

        [JsonPropertyName("qv")]
        public double VFlow { get; set; } = 6000;

        public override string ToString() =>
           JsonSerializer.Serialize(this);
    }
}