using Newtonsoft.Json;

namespace BalticMarinasClient.Models
{
    public class Reservation
    {
        [JsonProperty("ReservationId")]
        public int ReservationId { get; set; }

        [JsonProperty("BerthId")]
        public int BerthId { get; set; }

        [JsonProperty("CustomerId")]
        public int CustomerId { get; set; }

        [JsonProperty("CheckIn")]
        public string CheckIn { get; set; }

        [JsonProperty("CheckOut")]
        public string CheckOut { get; set; }

        [JsonProperty("IsPaid")]
        public int IsPaid { get; set; }
    }
}
