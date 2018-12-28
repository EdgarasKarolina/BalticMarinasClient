using Newtonsoft.Json;
using System;

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

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }
    }
}
