﻿using ChannelEngineBusinessLogic.Models;
using ChannelEngineBusinessLogic.Models.Orders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services
{
    public class OrderAppService : IOrderAppService
    {
        HttpClient _client;
        private const string API_KEY = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string BASE_URL = "https://api-dev.channelengine.net/api/v2/";
        public OrderAppService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
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

        public async Task GetTopFiveOrders()
        {
            var allOrders = await GetAllOrders();

        }


    }
}
