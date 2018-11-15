using Newtonsoft.Json;

namespace BalticMarinasClient.Models.Weather
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
