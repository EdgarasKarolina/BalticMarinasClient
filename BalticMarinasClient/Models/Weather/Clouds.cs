using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int all { get; set; }
    }
}
