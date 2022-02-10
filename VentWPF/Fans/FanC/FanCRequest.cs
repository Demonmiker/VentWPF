using PropertyTools.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using VentWPF.ViewModel;
using VentWPF.Model.Calculations;

namespace VentWPF.Fans.FanSelect
{
    /// <summary>
    /// Класс запроса для FanSelect
    /// </summary>
    internal class FanCRequest : BaseViewModel, IRequest<string>
    {
        [Category("Запрос")]
        [JsonPropertyName("insert_geo_data")]
        public bool InsertGeoData { get; set; } = true;

        [JsonPropertyName("insert_motor_data")]
        public bool InsertMotorData { get; set; } = true;

        [JsonPropertyName("insert_nominal_values")]
        public bool InsertNominalValues { get; set; } = true;

        [JsonPropertyName("language")]
        public string Language { get; set; } = "RU";

        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "password";

        [JsonPropertyName("psf")]
        public double PressureDrop { get; set; }

        [JsonPropertyName("installation_height_mm")]
        public double InstHeight { get; set; }

        [JsonPropertyName("installation_width_mm")]
        public double InstWidth { get; set; }

        [JsonPropertyName("search_tolerance")]
        public double SearchTolerance { get; set; } = 10;

        [JsonPropertyName("unit_system")]
        public string UnitSystem { get; set; } = "m";

        [JsonPropertyName("voltage")]
        public double Voltage { get; set; } = 230;

        [JsonPropertyName("username")]
        public string Username { get; set; } = "login";

        [JsonPropertyName("qv")]
        public double VFlow { get; set; }

        [JsonPropertyName("fan_type")]
        public string FanType { get; set; }

        public string GetRequest() => JsonSerializer.Serialize(this);
    }
}