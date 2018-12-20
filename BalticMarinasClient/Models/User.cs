using BalticMarinasClient.Utilities.Validation.UserValidation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Models
{
    public class User
    {
        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [Required]
        [UserName]
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [Required]
        [UserPassword]
        [JsonProperty("UserPassword")]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Firstname")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [Required]
        [UserEmail]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Max 12 characters")]
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("IsAdmin")]
        public int IsAdmin { get; set; }
    }
}
