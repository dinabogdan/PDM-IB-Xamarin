using InternetBanking.Model;
using InternetBanking.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.Data
{
    public class RestService
    {
        HttpClient client;
        

        public List<Account> Items { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            
        }

     
        public async Task<List<Account>> GetUserAccounts()
        {
            var uri = new Uri(string.Format(Constants.UsersUrl, string.Empty));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<Account>>(content);
            }

            return Items;
        }
    }
}
