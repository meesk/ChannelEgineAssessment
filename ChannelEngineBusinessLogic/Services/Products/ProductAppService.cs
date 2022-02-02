using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services.Products
{
    public class ProductAppService
    {
        HttpClient _client;
        private const string API_KEY = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string BASE_URL = "https://api-dev.channelengine.net/api/v2/";
        public ProductAppService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        protected void GetSingleProduct()
        {

        }
    }
}
