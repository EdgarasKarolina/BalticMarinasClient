using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BalticMarinasClient.ApiClient
{
    public class UserClient
    {
        private string userServiceBase = "https://localhost:44300/api/user";

        public async Task<int> AuthenticateUser(string userName, string password)
        {
            var result = string.Empty;
            var userAuthenticated = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.userServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = userServiceBase + "/" + userName + "/" + password;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    userAuthenticated = JsonConvert.DeserializeObject<int>(result);
                    return userAuthenticated;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        /*
        public async void CreateUser(int berthId, int customerId, string checkIn, string checkOut)
        {
            Reservation reservation = new Reservation();
            reservation.BerthId = berthId;
            reservation.CustomerId = customerId;
            reservation.CheckIn = checkIn;
            reservation.CheckOut = checkOut;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(reservation);

                HttpResponseMessage response = await client.PostAsync(reservationServiceBase + "/" + berthId + "/" + customerId + "/" + checkIn + "/" + checkOut, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        } */
    }
}
