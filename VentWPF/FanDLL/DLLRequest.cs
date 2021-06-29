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
        public string username { get; set; } = "login";
        public string password { get; set; } = "password";
        public double qv { get; set; } = 6000;
        public double psf { get; set; } = 150;
        public double search_tolerance { get; set; } = 10;
        public string language { get; set; } = "RU";
        public string unit_system { get; set; } = "m";
        public bool insert_geo_data { get; set; } = true;
        public bool insert_motor_data { get; set; } = true;
        public bool insert_nominal_values { get; set; } = true;
        [JsonIgnore]
        public string Req => this.ToString();

        public override string ToString() =>
           JsonSerializer.Serialize(this,new() {});


    }

    

}
