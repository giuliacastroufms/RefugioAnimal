using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RefugioAnimal.Models;
using RefugioAnimal.Models.DTOs;
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
            var filter = new AnimalFilterDto()
            { 
                AdoptionStatus = 0,
                MaxResultCount = 8,
                SkipCount = 0
            };

            var listAnimals = await _animalService.GetAllAnimalsAsync(filter);
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
