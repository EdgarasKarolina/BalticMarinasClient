using BalticMarinasClient.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BalticMarinasClient.ApiClient
{
    public class EmailClient
    {
        private string emailServiceBase = "https://localhost:44392/api/email";

        public async void CreateReservation(string emailBody, string receiver)
        {
            Email email = new Email();
            email.EmailBody = emailBody;
            email.Receiver = receiver;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.emailServiceBase);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(email);

                HttpResponseMessage response = await client.PostAsync(emailServiceBase + "/" + emailBody + "/" + receiver, new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
