using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Webhook.Infraestructure.Interfaces;

namespace Webhook.Infraestructure.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _HttpClient;

        public HttpService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<bool> PostAsync<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _HttpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}
