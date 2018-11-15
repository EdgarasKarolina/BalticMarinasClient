using Newtonsoft.Json;

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
