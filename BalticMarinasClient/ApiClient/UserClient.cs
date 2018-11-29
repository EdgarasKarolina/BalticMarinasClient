using BalticMarinasClient.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BalticMarinasClient.ApiClient
{
    public class UserClient
    {
        private string userServiceBase = "https://localhost:44315/api/user/";

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

        public async Task<int> GetUserId(string userName, string password)
        {
            var result = string.Empty;
            var userId = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.userServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = userServiceBase + "/" + "userId" + "/" + userName + "/" + password;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }

                    userId = JsonConvert.DeserializeObject<int>(result);
                    return userId;
                }
                catch (Exception e)
                {
                    throw new Exception($"Error: {e.StackTrace}");
                }
            }
        }

        public async void CreateUser(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.userServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(user);

                HttpResponseMessage response = await client.PostAsync(userServiceBase, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        } 
    }
}
