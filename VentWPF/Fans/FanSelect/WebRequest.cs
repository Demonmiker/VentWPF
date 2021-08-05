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

        public WebRequest(DllRequest req,string id)
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

    }
}
