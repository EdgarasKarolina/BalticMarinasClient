using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class Email
    {
        [JsonProperty("EmailBody")]
        public string EmailBody { get; set; }

        [JsonProperty("Receiver")]
        public string Receiver { get; set; }
    }
}
