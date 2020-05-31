using System.Net.Http;

namespace Wspolnota_MVC.Services
{
    public interface IAPIService
    {
        public HttpClient Client { get; }
    }
}