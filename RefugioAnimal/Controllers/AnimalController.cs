using Microsoft.AspNetCore.Mvc;
using RefugioAnimal.Models;
using RefugioAnimal.Models.Enums;
using RefugioAnimal.Services;

namespace RefugioAnimal.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalService _animalService;

        public AnimalController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var cats = await _animalService.GetAnimalsBySpecieAsync(Species.Cat, 4);
            var dogs = await _animalService.GetAnimalsBySpecieAsync(Species.Dog, 8);

            var viewModel = new AnimalViewModel
            {
                Cats = cats,
                Dogs = dogs
            };

            return View(viewModel);
        }
    }
}
