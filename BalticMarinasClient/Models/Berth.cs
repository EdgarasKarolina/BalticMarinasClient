using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models
{
    public class Berth
    {
        [JsonProperty("BerthId")]
        public int BerthId { get; set; }

        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }
    }
}
