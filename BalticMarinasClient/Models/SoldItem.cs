using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class SoldItem
    {
        [JsonProperty("SoldItemId")]
        public int SoldItemId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("MadeYear")]
        public string MadeYear { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }
    }
}
