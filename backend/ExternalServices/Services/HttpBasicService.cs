using ExternalServices.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices.Services
{
    public abstract class HttpBasicService
    {
        private readonly HttpClient httpClient;
        protected string apiEndpoint;

        public HttpBasicService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        protected async Task<HttpResponseMessage> GetAsync(string endpoint, Dictionary<string, string> parameters = null)
        {
            var url = new UrlBuilder()
                .AddRoute(apiEndpoint)
                .AddRoute(endpoint)
                .AddQuery(parameters)
                .Build();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw CreateException(nameof(GetAsync), response);
            }

            return response;
        }

        protected async Task<T> GetAsync<T>(string endpoint, Dictionary<string,string> parameters = null)
        {
            var response = await GetAsync(endpoint, parameters);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            throw CreateException(nameof(GetAsync), response);
        }

        private static Exception CreateException(string methodName, HttpResponseMessage response)
        {
            return new Exception($"{methodName}: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}
