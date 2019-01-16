using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Models
{
    public class SoldItem
    {
        [JsonProperty("SoldItemId")]
        public int SoldItemId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("MadeYear")]
        public string MadeYear { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }
    }
}
