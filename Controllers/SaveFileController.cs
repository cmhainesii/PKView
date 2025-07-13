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

        // GET: Upload save file
        public ActionResult Upload()
        {
            return View();
        }

        // POST: Handle file upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(IFormFile saveFile)
        {
            if (saveFile == null || saveFile.Length == 0)
            {
                ViewBag.ErrorMessage = "Please select a save file to upload.";
                return View();
            }

            // Validate file extension
            var allowedExtensions = new[] { ".sav", ".srm" };
            var fileExtension = Path.GetExtension(saveFile.FileName).ToLowerInvariant();
            
            if (!allowedExtensions.Contains(fileExtension))
            {
                ViewBag.ErrorMessage = "Invalid file type. Please upload a .sav or .srm file.";
                return View();
            }

            // Validate file size (max 32KB for Pokemon save files)
            if (saveFile.Length > 32768)
            {
                ViewBag.ErrorMessage = "File size too large. Pokemon save files should be 32KB or smaller.";
                return View();
            }

            try
            {
                // Create uploads directory if it doesn't exist
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsPath, fileName);

                // Save the uploaded file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await saveFile.CopyToAsync(stream);
                }

                // Try to load the save file to validate it
                try
                {
                    var gameData = new GameData(filePath);
                    var model = new SaveFileViewModel(gameData);
                    
                    ViewBag.SuccessMessage = $"Save file '{saveFile.FileName}' uploaded successfully!";
                    ViewBag.UploadedFile = fileName;
                    ViewBag.SaveFileData = model;
                    
                    return View();
                }
                catch (Exception ex)
                {
                    // Delete the invalid file
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    
                    ViewBag.ErrorMessage = $"Invalid save file format: {ex.Message}";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error uploading file: {ex.Message}";
                return View();
            }
        }

        // Action to analyze uploaded save file
        public ActionResult Analyze(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return RedirectToAction("Upload");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);
            
            if (!System.IO.File.Exists(filePath))
            {
                ViewBag.ErrorMessage = "Save file not found.";
                return RedirectToAction("Upload");
            }

            try
            {
                var gameData = new GameData(filePath);
                var model = new SaveFileViewModel(gameData);
                return View("Index", model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error loading save file: {ex.Message}";
                return RedirectToAction("Upload");
            }
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
