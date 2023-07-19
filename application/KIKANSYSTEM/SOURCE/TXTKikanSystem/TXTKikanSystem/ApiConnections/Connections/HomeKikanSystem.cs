using System.Net.Http;
using System;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace TXTKikanSystem.ApiConnections.Connections
{
    public class HomeKikanSystem : IHomeKikanSystem
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory httpClientFactory;

        public HomeKikanSystem(IConfiguration _configuration, IHttpClientFactory _httpClientFactory)
        {
            this.configuration = _configuration;
            this.httpClientFactory = _httpClientFactory;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<string> Initialization(string request)
        {
            try
            {
                HttpClient client = httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(this.configuration["LocalhostCloud"]);
                HttpResponseMessage response = await client.PostAsJsonAsync(CommonApi.CommonUrlDefaultApi.InitializationHome_Post, request);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
