using ChannelEngineBusinessLogic.Models;
using ChannelEngineBusinessLogic.Services.Orders;
using ChannelEngineBusinessLogic.Services.Products;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            var orders = await OrdersWithDependencyInjection(host.Services);
            foreach(var product in orders)
            {
                Console.WriteLine("ProductNo: " + product.MerchantProductNo);
                Console.WriteLine("GTIN: " + product.Gtin);
                Console.WriteLine("Quantity: " + product.Quantity);
            }
        }

        public static async Task<IEnumerable<Line>> OrdersWithDependencyInjection(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var orderAppService = provider.GetRequiredService<IOrderAppService>();

            return await orderAppService.GetTopFiveOrders();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddHttpClient<IOrderAppService, OrderAppService>();
                    services.AddHttpClient<IProductAppService, ProductAppService>();
                });
        }
    }
}
