using System.Text.Json.Serialization;

namespace VentWPF.Fans.FanSelect
{
    /// <summary>
    /// Веб запрос к FanSelect API
    /// </summary>
    internal class WebRequest : FanCRequest
    {
        public WebRequest(FanCRequest req, string id)
        {
            this.SessionID = id;
            this.Password = req.Password;
            this.PressureDrop = req.PressureDrop;
            this.SearchTolerance = req.SearchTolerance;
            this.UnitSystem = req.UnitSystem;
            this.Username = req.Username;
            this.VFlow = req.VFlow;
            this.InsertGeoData = req.InsertGeoData;
            this.InsertMotorData = req.InsertMotorData;
            this.InsertNominalValues = req.InsertNominalValues;
        }

        [JsonPropertyName("SESSION_ID")]
        public string SessionID { get; set; }
    }
}