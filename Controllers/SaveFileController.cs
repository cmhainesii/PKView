using Microsoft.AspNetCore.Mvc;
using PKLib;
using PKView.Models;

namespace MyApp.Namespace
{
    public class SaveFileController : Controller
    {

        GameData saveData = new GameData(fileName);

        private const string fileName = "crystal.srm";
        // GET: SaveFileController
        public ActionResult Index()
        {
            GameData saveData = new GameData(fileName);
            SaveFileViewModel model = new SaveFileViewModel(saveData);
            return View(model);
        }

        public ActionResult TrainerCard()
        {
            SaveFileViewModel model = new SaveFileViewModel(saveData);
            return View(model);
        }

        public ActionResult Index_Iteration1()
        {
            
            SaveFileViewModel model = new SaveFileViewModel(saveData);
            return View(model);
        }

        public ActionResult Index_Iteration2()
        {
            GameData saveData = new GameData(fileName);
            SaveFileViewModel model = new SaveFileViewModel(saveData);
            return View(model);
        }
        

        public ActionResult Index_Iteration4()
        {
            GameData saveData = new GameData(fileName);
            SaveFileViewModel model = new SaveFileViewModel(saveData);
            return View(model);
        }

    }
}
