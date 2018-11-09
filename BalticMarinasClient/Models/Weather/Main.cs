using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min")]
        public string Temp_min { get; set; }

        [JsonProperty("temp_max")]
        public string Temp_max { get; set; }
    }
}
