using BalticMarinasClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BalticMarinasClient.ApiClient
{
    public class BookMarinaClient
    {
        private string marinaServiceBase = "https://localhost:44300/api/marina";
        private string berthServiceBase = "https://localhost:44300/api/berth";
        private string reservationServiceBase = "https://localhost:44300/api/reservation/";

        #region Marinas methods
        public async Task<ObservableCollection<Marina>> GetAllMarinas()
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = marinaServiceBase;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Marina>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async Task<Marina> GetMarinaById(int? marinaId)
        {
            var result = string.Empty;
            var marinaResult = new Marina();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = marinaServiceBase + "/" + marinaId;

                HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                try
                {
                    marinaResult = JsonConvert.DeserializeObject<Marina>(result);
                }
                catch (Exception e)
                {
                    //this.logger.Error($"Error in GetUserByEmail - {e}");
                }
            }

            return marinaResult;
        }

        public async Task<ObservableCollection<Marina>> GetMarinasByCountry(string country)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = marinaServiceBase + "/" + "country" + "/" + country;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Marina>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }
        #endregion

        #region Berths methods
        public async Task<ObservableCollection<Berth>> GetAllBerths()
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = berthServiceBase;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Berth>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async Task<ObservableCollection<Berth>> GetBerthsByMarinaId(int? marinaId)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = berthServiceBase + "/" + marinaId;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Berth>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async Task<Berth> GetBerthByMarinaIdAndBerthId(int? marinaId, int? berthId)
        {
            var result = string.Empty;
            var berthResult = new Berth();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.berthServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = berthServiceBase + "/" + marinaId + "/" + berthId;

                HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                try
                {
                    berthResult = JsonConvert.DeserializeObject<Berth>(result);
                }
                catch (Exception e)
                {
                    //this.logger.Error($"Error in GetUserByEmail - {e}");
                }
            }

            return berthResult;
        }

        public async Task<ObservableCollection<Berth>> GetAvailableBerthsByMarina(int? marinaId, string checkIn, string checkOut)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.berthServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = berthServiceBase + "/" + marinaId + "/" + checkIn + "/" + checkOut;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Berth>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        #endregion

        #region Reservation methods

        public async Task<ObservableCollection<Reservation>> GetAllReservationsByCustomerId(int customerId)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = reservationServiceBase + customerId;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Reservation>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async Task<int> GetReservationId(int berthId, int customerId, string checkIn, string checkOut)
        {
            var result = string.Empty;
            var reservationId = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = reservationServiceBase + berthId + "/" + customerId + "/" + checkIn + "/" + checkOut;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    reservationId = JsonConvert.DeserializeObject<int>(result);
                    int res = await Task.FromResult<int>(reservationId);
                    return res;

                    //return reservationId;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async void CreateReservation(Reservation reservation)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(reservation);

                HttpResponseMessage response = await client.PostAsync(reservationServiceBase, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        }

        public async void UpdateReservation(int? reservationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsync(reservationServiceBase + "/" + reservationId, null);
                response.EnsureSuccessStatusCode();
            }
        }

        public async void DeleteNotPaidReservation(int? reservationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(reservationServiceBase + reservationId);
                response.EnsureSuccessStatusCode();
            }
        }

        #endregion
    }
}
