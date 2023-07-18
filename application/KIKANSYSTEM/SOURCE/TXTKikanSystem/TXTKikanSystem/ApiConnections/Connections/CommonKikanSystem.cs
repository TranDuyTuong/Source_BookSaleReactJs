using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;

namespace TXTKikanSystem.ApiConnections.Connections
{
    public class CommonKikanSystem : ICommonKikanSystem
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory httpClientFactory;

        public CommonKikanSystem(IConfiguration _configuration, IHttpClientFactory _httpClientFactory)
        {
            this.configuration = _configuration;
            this.httpClientFactory = _httpClientFactory;
        }

        /// <summary>
        /// ValidationEmployeerSignIn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<string> ValidationEmployeerSignIn(string request)
        {
            try
            {
                HttpClient client = httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(this.configuration["LocalhostCloud"]);
                HttpResponseMessage response = await client.PostAsJsonAsync(CommonApi.CommonUrlDefaultApi.TokenValidation_Post, request);
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
