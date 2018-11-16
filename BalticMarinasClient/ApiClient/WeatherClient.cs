using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BalticMarinasClient.ApiClient
{
    public class WeatherClient
    {
        private string serviceBase = "http://api.openweathermap.org/data/2.5/group?id=598098,596612,598316,594050,457138,595087&APPID=2dca90787552469233eb9eda9f1dfac4&units=metric";

        public async Task<ObservableCollection<Models.Weather.ResponseWeather>> GetAllWeather()
        {
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.serviceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var urlAddress = serviceBase;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAddress).ConfigureAwait(continueOnCapturedContext: false);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        result = result.Remove(0, 16);
                        result = result.Remove(result.Length - 1);
                    }

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Models.Weather.ResponseWeather>>(result);
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
