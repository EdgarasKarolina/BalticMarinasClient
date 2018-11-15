using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
