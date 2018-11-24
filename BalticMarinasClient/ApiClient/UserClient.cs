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

                var urlAddress = userServiceBase + userName + "/" + password;

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
    }
}
