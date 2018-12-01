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
    public class SellBuyClient
    {
        private string soldItemServiceBase = "https://localhost:44389/api/solditem";

        public async Task<ObservableCollection<SoldItem>> GetAllSoldItems()
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.soldItemServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = soldItemServiceBase;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<SoldItem>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async Task<ObservableCollection<SoldItem>> GetAllSoldItemsByUserId(int userId)
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.soldItemServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = soldItemServiceBase + "/" + "user" + "/" + userId;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<SoldItem>>(result);
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async Task<SoldItem> GetSoldItemById(int? soldItemId)
        {
            var result = string.Empty;
            var soldItemResult = new SoldItem();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.soldItemServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = soldItemServiceBase + "/" + soldItemId;

                HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                try
                {
                    soldItemResult = JsonConvert.DeserializeObject<SoldItem>(result);
                }
                catch (Exception e)
                {
                    //this.logger.Error($"Error in GetUserByEmail - {e}");
                }
            }

            return soldItemResult;
        }

        public async void CreateSoldItem(SoldItem soldItem)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.soldItemServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(soldItem);

                HttpResponseMessage response = await client.PostAsync(soldItemServiceBase, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        }

        public async void DeleteSoldItemById(int? soldItemId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.soldItemServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(soldItemServiceBase + "/" + soldItemId);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
