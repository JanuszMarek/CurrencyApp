using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExtendedServices.Services
{
    public abstract class HttpBasicService
    {
        private readonly HttpClient httpClient;

        public HttpBasicService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            throw new Exception($"{nameof(GetAsync)}: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}
