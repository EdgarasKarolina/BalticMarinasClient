using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class Weather
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("main")]
        public string main { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("icon")]
        public string icon { get; set; }
    }
}
