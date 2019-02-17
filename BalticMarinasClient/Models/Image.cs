using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.Models
{
    public class Image
    {
        [JsonProperty("Image")]
        public string ImageData { get; set; }

        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }
    }
}
