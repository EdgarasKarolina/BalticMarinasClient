using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BalticMarinasClient.Models
{
    public class Marina
    {
        [JsonProperty("MarinaId")]
        public int MarinaId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("MarinaName")]
        public string MarinaName { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Max 12 characters")]
        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("Depth")]
        public double Depth { get; set; }

        [Required]
        [JsonProperty("CityName")]
        public string CityName { get; set; }

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [Required]
        [JsonProperty("ZipCodeNumber")]
        public string ZipCodeNumber { get; set; }

        [Required]
        [JsonProperty("TotalBerths")]
        public int TotalBerths { get; set; }

        [Required]
        [JsonProperty("IsToilet")]
        public int IsToilet { get; set; }

        [Required]
        [JsonProperty("IsShower")]
        public int IsShower { get; set; }

        [Required]
        [JsonProperty("IsInternet")]
        public int IsInternet { get; set; }

        [Required]
        [JsonProperty("IsPharmacy")]
        public int IsPharmacy { get; set; }

        [Required]
        [JsonProperty("IsElectricity")]
        public int IsElectricity { get; set; }

        [Required]
        [JsonProperty("IsRepairing")]
        public int IsRepairing { get; set; }

        [Required]
        [JsonProperty("IsStore")]
        public int IsStore { get; set; }

        [Required]
        [JsonProperty("IsTelephone")]
        public int IsTelephone { get; set; }

        [Required]
        [JsonProperty("IsHotel")]
        public int IsHotel { get; set; }

        [Required]
        [JsonProperty("IsCafeteria")]
        public int IsCafeteria { get; set; }

        [Required]
        [JsonProperty("Description")]
        public string Description { get; set; }


    }
}
