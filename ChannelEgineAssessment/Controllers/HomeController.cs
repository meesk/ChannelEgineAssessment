using ChannelEgineAssessment.Models;
using ChannelEngineBusinessLogic.Services.Orders;
using ChannelEngineBusinessLogic.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEgineAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderAppService _orderAppService;
        private readonly IProductAppService _productAppService;

        public HomeController(ILogger<HomeController> logger, IOrderAppService orderAppService, IProductAppService productAppService)
        {
            _logger = logger;
            _orderAppService = orderAppService;
            _productAppService = productAppService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderAppService.GetTopFiveOrders();
            return View(orders);
        }

        public async Task<ActionResult> SetStockToTwentyFive(string merchantProductNo)
        {
            var success = await _productAppService.UpdateProductStock(merchantProductNo, 25);
            if (!success)
            {
                // error
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
