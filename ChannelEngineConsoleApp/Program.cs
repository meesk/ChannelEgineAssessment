using ChannelEngineBusinessLogic.Models;
using ChannelEngineBusinessLogic.Services;
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
        }

        public static async Task<Order> OrdersWithDependencyInjection(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var orderAppService = provider.GetRequiredService<IOrderAppService>();

            return await orderAppService.GetOrders();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                services.AddHttpClient<IOrderAppService, OrderAppService>());
        }
    }
}
