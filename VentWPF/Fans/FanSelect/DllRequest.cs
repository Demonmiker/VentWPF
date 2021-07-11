using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.Tools;
using VentWPF.ViewModel;
using PropertyTools.DataAnnotations; using static VentWPF.ViewModel.Strings;
using System.ComponentModel.DataAnnotations;

namespace VentWPF.Fans.FanSelect
{
    
    internal class DllRequest : BaseViewModel , IRequest<string>
    {
        [Category("Запрос")]
        [JsonPropertyName("insert_geo_data")]
        public bool InsertGeoData { get; set; } = true;

        [JsonPropertyName("insert_motor_data")]
        public bool insertMotorData { get; set; } = true;

        [JsonPropertyName("insert_nominal_values")]
        public bool InsertNominalValues { get; set; } = true;

        [JsonPropertyName("language")]
        public string Language { get; set; } = "RU";

        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
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

        public string GetRequest() => JsonSerializer.Serialize(this);

    }
}