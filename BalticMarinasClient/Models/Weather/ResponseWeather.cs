using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class ResponseWeather
    {
        [JsonProperty("coord")]
        public Coord coord { get; set; }
        [JsonProperty("weather")]
        public List<Weather> weather { get; set; }
        [JsonProperty("@base")]
        public string @base { get; set; }
        [JsonProperty("main")]
        public Main main { get; set; }
        [JsonProperty("visibility")]
        public int visibility { get; set; }
        [JsonProperty("wind")]
        public Wind wind { get; set; }
        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }
        [JsonProperty("dt")]
        public int dt { get; set; }
        [JsonProperty("sys")]
        public Sys sys { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("cod")]
        public int cod { get; set; }
    }
}
