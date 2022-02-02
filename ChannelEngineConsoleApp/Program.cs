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
        static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            var orders = GreetWithDependencyInjection(host.Services);

            foreach(var order in orders)
            {
                foreach(var line in order.Lines)
                {
                }
            }
            return host.RunAsync();
        }

        public static List<Order> GreetWithDependencyInjection(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var greeter = provider.GetRequiredService<IOrderAppService>();

            return greeter.GetOrders();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IOrderAppService, OrderAppService>());
        }
    }
}
