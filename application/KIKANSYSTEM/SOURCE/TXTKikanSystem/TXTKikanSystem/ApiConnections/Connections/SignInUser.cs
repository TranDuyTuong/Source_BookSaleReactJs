using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;

namespace TXTKikanSystem.ApiConnections.Connections
{
    public class SignInUser : ISignInUser
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory httpClientFactory;

        public SignInUser(IConfiguration _configuration, IHttpClientFactory _httpClientFactory)
        {
            this.configuration = _configuration;
            this.httpClientFactory = _httpClientFactory;
        }

        /// <summary>
        /// ApiLoginUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> ApiLoginUser(string request)
        {
            try {
                HttpClient client = httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(this.configuration["LocalhostCloud"]);
                HttpResponseMessage response = await client.PostAsJsonAsync(CommonApi.CommonUrlDefaultApi.UserLogin_Post, request);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

    }
}
