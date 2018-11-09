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
        public double temp { get; set; }
        [JsonProperty("pressure")]
        public string pressure { get; set; }
        //public int pressure { get; set; }
        [JsonProperty("humidity")]
        public int humidity { get; set; }
        [JsonProperty("temp_min")]
        public string temp_min { get; set; }
        [JsonProperty("temp_max")]
        public string temp_max { get; set; }
    }
}
