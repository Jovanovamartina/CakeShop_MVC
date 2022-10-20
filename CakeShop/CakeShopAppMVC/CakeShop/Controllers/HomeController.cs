using CakeShop.Business.Abstraction;
using CakeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICakeService _cakeService;

        public HomeController(ILogger<HomeController> logger, ICakeService cakeService)
        {
            _logger = logger;
            _cakeService = cakeService;
        }

        public IActionResult Index()
        {
            return View(_cakeService.RandomCakes());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}