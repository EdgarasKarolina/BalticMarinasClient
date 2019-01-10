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
        private string marinaServiceBase = "https://localhost:44300/api/marinas/";
        private string berthServiceBase = "https://localhost:44300/api/berths/";
        private string reservationServiceBase = "https://localhost:44300/api/reservations/";
        private string commentServiceBase = "https://localhost:44300/api/comments/";

        #region Marinas methods

        public async void CreateMarina(Marina marina)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(marina);

                HttpResponseMessage response = await client.PostAsync(marinaServiceBase, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        }

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

                var urlAddress = marinaServiceBase + marinaId;

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

                var urlAddress = marinaServiceBase + "countries" + "/" + country + "/" + "marinas";

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

        public async void DeleteMarinaById(int? marinaId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.marinaServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(marinaServiceBase + marinaId);
                response.EnsureSuccessStatusCode();
            }
        }
        #endregion

        #region Berths methods

        public async void CreateBerth(Berth berth)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.berthServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(berth);

                HttpResponseMessage response = await client.PostAsync(berthServiceBase, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        }

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

                var urlAddress = berthServiceBase + "marinas" + "/" + marinaId + "/" + "berths";

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

                var urlAddress = berthServiceBase + "marinas" + "/" + marinaId + "/" + "berths" + "/" + berthId;

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

                var urlAddress = berthServiceBase + "marinas" + "/" + marinaId + "/" + "berths" + "/" + "checkin" + "/" + checkIn + "/" + "checkout" + "/" + checkOut;

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

        public async void DeleteBerthById(int? berthId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.berthServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(berthServiceBase + berthId);
                response.EnsureSuccessStatusCode();
            }
        }

        #endregion

        #region Reservation methods

        public async Task<int> GetIfReservationExists(int reservationId)
        {
            var result = string.Empty;
            var reservationExists = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = reservationServiceBase + "reservations" + "/" + reservationId;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    reservationExists = JsonConvert.DeserializeObject<int>(result);
                    return reservationExists;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }
       
        public async Task<ObservableCollection<Reservation>> GetAllReservationsByCustomerId(int customerId)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.reservationServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = reservationServiceBase + "customers" + "/" + customerId + "/" + "reservations";

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

                var urlAddress = reservationServiceBase + "berths" + "/" + berthId + "/" + "customers" + "/" + customerId + "/" + "checkin" + "/" + checkIn + "/" + "checkout" + "/" + checkOut;

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

                HttpResponseMessage response = await client.PutAsync(reservationServiceBase + reservationId, null);
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

        #region Comment methods

        public async Task<ObservableCollection<Comment>> GetAllCommentsByMarinaId(int? marinaId)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.commentServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = commentServiceBase + "marinas" + "/" + marinaId + "/" + "comments";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Comment>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async void CreateComment(Comment comment)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.commentServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(comment);

                HttpResponseMessage response = await client.PostAsync(commentServiceBase, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        }

        #endregion
    }
}
