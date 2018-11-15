using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class Marina
    {
        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }

        [JsonProperty("MarinaName")]
        public string MarinaName { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Depth")]
        public double Depth { get; set; }

        [JsonProperty("CityName")]
        public string CityName { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("ZipCodeNumber")]
        public string ZipCodeNumber { get; set; }

        [JsonProperty("TotalBerths")]
        public int TotalBerths { get; set; }

        [JsonProperty("IsToilet")]
        public int IsToilet { get; set; }

        [JsonProperty("IsShower")]
        public int IsShower { get; set; }

        [JsonProperty("IsInternet")]
        public int IsInternet { get; set; }
    }
}
