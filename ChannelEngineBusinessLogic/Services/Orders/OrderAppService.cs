using ChannelEngineBusinessLogic.Models;
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
        private readonly HttpClient _client;
        private readonly IProductAppService _productAppService;
        private const string API_KEY = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string BASE_URL = "https://api-dev.channelengine.net/api/v2/";
        public OrderAppService(HttpClient client, IProductAppService productAppService)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _productAppService = productAppService;
        }

        private async Task<Order> GetOrdersInProgress()
        {
            var path = $"{BASE_URL}orders?statuses=IN_PROGRESS&apikey={API_KEY}";
            HttpResponseMessage response  = await _client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
                return null;

            var responseResult = response.Content.ReadAsStringAsync().Result;
            var resultObj = JsonConvert.DeserializeObject<Order>(responseResult);
            return resultObj;
        }

        public async Task<IEnumerable<Line>> GetTopFiveOrders()
        {
            var ordersInProgress = await GetOrdersInProgress();

            var orderLines = ordersInProgress.Content.SelectMany(orders => orders.Lines).GroupBy(x => x.MerchantProductNo).Select(x => {
                var ret = x.First();
                ret.Quantity = x.Sum(xt => Convert.ToInt32(xt.Quantity));
                return ret;
            }).OrderByDescending(line => line.Quantity);
            return orderLines;
        }


    }
}
