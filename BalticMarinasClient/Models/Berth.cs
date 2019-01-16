using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Models
{
    public class Berth
    {
        [JsonProperty("BerthId")]
        public int BerthId { get; set; }

        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }

        [Required]
        [JsonProperty("Price")]
        public double Price { get; set; }
    }
}
