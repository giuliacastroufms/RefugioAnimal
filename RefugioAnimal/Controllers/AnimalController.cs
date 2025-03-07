using Microsoft.AspNetCore.Authorization;
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
            var cats = await _animalService.GetAnimalsBySpecieAsync(Species.Cat, 4, 0);
            var dogs = await _animalService.GetAnimalsBySpecieAsync(Species.Dog, 8, 0);
            var adoptedAnimals = await _animalService.GetAdoptedAnimalsAsync(4);
            var randomAnimal = await _animalService.GetRandomAnimalAsync(null);

            var viewModel = new AnimalViewModel
            {
                Cats = cats,
                Dogs = dogs,
                AdoptedAnimals = adoptedAnimals,
                RandomAnimal = randomAnimal
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Cats()
        {
            var cats = await _animalService.GetAnimalsBySpecieAsync(Species.Cat, 24, 0);

            var viewModel = new CatsViewModel
            {
                Cats = cats
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Dogs()
        {
            var dogs = await _animalService.GetAnimalsBySpecieAsync(Species.Dog, 24, 0);

            var viewModel = new DogsViewModel
            {
                Dogs = dogs
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AnimalSpecies()
        {
            var cats = await _animalService.GetAnimalsBySpecieAsync(Species.Cat, 1, 0);
            var dogs = await _animalService.GetAnimalsBySpecieAsync(Species.Dog, 1, 0);

            var viewModel = new AnimalSpeciesViewModel
            {
                Cats = cats,
                Dogs = dogs
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AnimalProfile(long animalId)
        {
            var animal = await _animalService.GetAnimalByIdAsync(animalId);

            if (animal == null)
            {
                return NotFound();
            }

            var viewModel = new AnimalProfileViewModel
            {
                Animal = animal
            };

            return View(viewModel);

        }
    }
}
