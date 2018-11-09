using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models.Weather
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double speed { get; set; }
        [JsonProperty("deg")]
        public string deg { get; set; }
    }
}
