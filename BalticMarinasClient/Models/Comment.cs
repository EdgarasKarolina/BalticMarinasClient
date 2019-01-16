using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Models
{
    public class Comment
    {
        [JsonProperty("CommentId")]
        public int CommentId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("TimePlaced")]
        public DateTime TimePlaced { get; set; }

        [Required]
        [StringLength(1200, ErrorMessage = "Max 1200 characters")]
        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }
    }
}
