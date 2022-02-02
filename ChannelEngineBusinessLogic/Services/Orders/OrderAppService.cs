using ChannelEngineBusinessLogic.Models;
using ChannelEngineBusinessLogic.Models.Orders;
using ChannelEngineBusinessLogic.Services.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services.Orders
{
    public class OrderAppService : IOrderAppService
    {
        HttpClient _client;
        IProductAppService _productAppService;
        private const string API_KEY = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string BASE_URL = "https://api-dev.channelengine.net/api/v2/";
        public OrderAppService(HttpClient client, IProductAppService productAppService)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _productAppService = productAppService;
        }

        private async Task<Order> GetAllOrders()
        {
            var path = $"{BASE_URL}orders?apikey={API_KEY}";
            HttpResponseMessage response  = await _client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
                return null;

            var responseResult = response.Content.ReadAsStringAsync().Result;
            var resultObj = JsonConvert.DeserializeObject<Order>(responseResult);
            return resultObj;
        }

        public async Task<Order> GetTopFiveOrders()
        {
            var allOrders = await GetAllOrders();

            var orderLines = new List<Line>();
            foreach(var content in allOrders.Content)
            {
                foreach(var line in content.Lines)
                {
                    orderLines.Add(line);
                }
            }

            var groupedLines = orderLines.GroupBy(line => line.MerchantProductNo);
            var sortedLines = groupedLines.OrderByDescending(line => line.Sum(x => x.Quantity));
            return null;
        }


    }
}
