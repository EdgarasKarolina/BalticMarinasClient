using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class Sys
    {
        [JsonProperty("type")]
        public int type { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("message")]
        public double message { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("sunrise")]
        public int sunrise { get; set; }
        [JsonProperty("sunset")]
        public int sunset { get; set; }
    }
}
