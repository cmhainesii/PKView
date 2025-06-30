using Microsoft.AspNetCore.Mvc;
using PKLib;
using PKView.Models;
using System.Diagnostics;

namespace PKView.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameData _saveFile;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GameData saveFile)
        {
            _logger = logger;
            _saveFile = saveFile;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GradientTutorial()
        {
            return View();
        }

        public IActionResult PokemonGradients()
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
