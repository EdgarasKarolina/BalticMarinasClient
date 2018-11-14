using BalticMarinasClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BalticMarinasClient.ApiClient
{
    public class BookMarinaClient
    {
        private string marinaServiceBase = "https://localhost:44300/api/marina";
        private string berthServiceBase = "https://localhost:44300/api/berth";

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
    }
}
