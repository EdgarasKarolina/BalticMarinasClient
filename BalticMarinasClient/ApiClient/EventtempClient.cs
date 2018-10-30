using BalticMarinasClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalticMarinasClient.ApiClient
{
    public partial class BaseClient
    {
        public async Task<List<Event>> GetEvents()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetAllUsers"));
            return await GetAsync<List<Event>>(requestUrl);
        }

        /*
        public async Task<Message<UsersModel>> SaveUser(UsersModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/SaveUser"));
            return await PostAsync<UsersModel>(requestUrl, model);
        }
        */
    }
}
