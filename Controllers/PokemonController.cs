using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class PokemonController : Controller
    {
        // GET: PokemonController
        public ActionResult Index()
        {
            return View();
        }

    }
}
