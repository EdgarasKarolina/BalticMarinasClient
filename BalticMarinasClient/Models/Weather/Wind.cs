using Newtonsoft.Json;

namespace BalticMarinasClient.Models.Weather
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public string Deg { get; set; }
    }
}
