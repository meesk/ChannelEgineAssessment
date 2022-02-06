using ChannelEngineBusinessLogic.Models.Products;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly HttpClient _client;
        private const string API_KEY = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string BASE_URL = "https://api-dev.channelengine.net/api/v2/";
        public ProductAppService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> UpdateProductStock(string merchantProductNo, int newAmount)
        {
            var path = $"{BASE_URL}products/{merchantProductNo}?apikey={API_KEY}";
            UpdateProductStock updateInfo = new UpdateProductStock()
            {
                Op = "Replace",
                Path = "Stock",
                Value = newAmount,
            };
            JsonContent content = JsonContent.Create(new List<UpdateProductStock>() { updateInfo });
            HttpResponseMessage response = await _client.PatchAsync(path, content);
            return response.IsSuccessStatusCode;
        }
    }
}
