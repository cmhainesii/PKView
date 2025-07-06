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
            return View(PokemonViewModel.ToPokemonViewList(_saveFile.PartyPokemon.GetParty()));
        }

        public IActionResult Index()
        {
            return View(new SaveFileViewModel(_saveFile));
        }

        public IActionResult TimeResetCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimeResetCode(string trainerName, int trainerId, int money)
        {
            // TODO: Implement time reset code generation logic here
            var timeResetCode = GenerateTimeResetCode(trainerName, trainerId, money);
            
            ViewBag.TrainerName = trainerName;
            ViewBag.TrainerId = trainerId;
            ViewBag.Money = money;
            ViewBag.TimeResetCode = timeResetCode;
            
            return View();
        }

        // Placeholder method for time reset code generation
        private string GenerateTimeResetCode(string trainerName, int trainerId, int money)
        {
            // TODO: Replace this with actual time reset code generation logic
            return PokemonUtil.GCSTimeResetPassword(trainerName, trainerId, money);
        }
    }
}
