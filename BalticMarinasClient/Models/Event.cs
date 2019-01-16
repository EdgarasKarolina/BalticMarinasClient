using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Models
{
    public class Event
    {
        [JsonProperty("EventId")]
        public int EventId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Location")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string Location { get; set; }

        [JsonProperty("Period")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string Period { get; set; }

        [Required]
        [StringLength(1200, ErrorMessage = "Max 1200 characters")]
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }
    }
}
