using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double lon { get; set; }
        [JsonProperty("lat")]
        public double lat { get; set; }
    }
}
