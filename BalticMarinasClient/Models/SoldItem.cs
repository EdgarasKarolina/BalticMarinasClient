using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class SoldItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sold")]
        public int Sold { get; set; }
    }
}
