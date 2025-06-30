using Microsoft.AspNetCore.Mvc;
using PKLib;
using PKView.Models;

namespace MyApp.Namespace
{
    public class PokemonController : Controller
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly GameData _saveFile;

        public PokemonController(ILogger<PokemonController> logger, GameData saveFile)
        {
            _logger = logger;
            _saveFile = saveFile;
        }
        // GET: PokemonController
        public IActionResult PokemonParty()
        {
            return View(PokemonViewModel.ToPokemonViewList(_saveFile.partyPokemon.GetParty()));
        }

        public IActionResult Index()
        {
            return View(new SaveFileViewModel(_saveFile));
        }

    }
}
