using HundeProjekt.Data;
using HundeProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HundeProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HundeProjektContext _context;

        public HomeController(ILogger<HomeController> logger, HundeProjektContext context)
        {
            _logger = logger;
            _context = context;
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
