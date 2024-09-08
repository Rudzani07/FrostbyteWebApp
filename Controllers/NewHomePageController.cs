using FrostbyteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrostbyteWebApp.Controllers
{
    public class NewHomePageController : Controller
    {
        private readonly ILogger<NewHomePageController> _logger;

        public NewHomePageController(ILogger<NewHomePageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
