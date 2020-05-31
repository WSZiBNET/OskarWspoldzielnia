using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Wspolnota_MVC.Services
{    
    public class UserService : IAPIService
    {
        public HttpClient Client { get; }

        public UserService(HttpClient client)
        {
            string address = "https://localhost:44383/";
            client.BaseAddress = new Uri(address);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            Client = client;
        }
    }
}
