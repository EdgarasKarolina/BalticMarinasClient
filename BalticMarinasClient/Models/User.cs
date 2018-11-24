using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class User
    {
        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("UserPassword")]
        public string UserPassword { get; set; }

        [JsonProperty("Firstname")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("IsAdmin")]
        public int IsAdmin { get; set; }
    }
}
