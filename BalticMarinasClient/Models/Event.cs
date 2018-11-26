using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class Event
    {
        [JsonProperty("EventId")]
        public int EventId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Period")]
        public string Period { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
