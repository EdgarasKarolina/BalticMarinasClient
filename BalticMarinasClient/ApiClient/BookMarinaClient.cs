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
    }
}
