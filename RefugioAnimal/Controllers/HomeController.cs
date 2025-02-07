using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RefugioAnimal.Models;
using RefugioAnimal.Services;

namespace RefugioAnimal.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimalService _animalService;

        public HomeController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var listAnimals = await _animalService.GetAllAnimalsAsync(8, 0);
            var viewModel = new AnimalViewModel
            {
                ListAnimals = listAnimals
            };

            return View(viewModel);
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
