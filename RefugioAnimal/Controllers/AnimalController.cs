using Microsoft.AspNetCore.Mvc;
using RefugioAnimal.Models;
using RefugioAnimal.Models.DTOs;
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
            var animals = await _animalService.GetAllAnimalsAsync();
            var viewModel = new AnimalViewModel
            {
                Animals = animals.ToList()
            };

            return View(viewModel);
        }

        [HttpGet] public async Task<IActionResult> GetAllAnimals() 
        { 
            var animals = await _animalService.GetAllAnimalsAsync();
            return Json(animals); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal(CreateAnimalDto dto)
        {
            if (dto is not null) { 
                await _animalService.CreateAnimalAsync(dto);
                return Json(new { success = true, message = "Animal criado com sucesso!" });
            }

            return Json(new { success = false, message = "Erro ao criar animal." });
        }

        [HttpPost]
        public async Task<IActionResult> EditAnimal(long id, UpdateAnimalDto dto)
        {
            try
            {
                await _animalService.UpdateAnimalAsync(id, dto);
                return Json(new { success = true, message = "Animal atualizado com sucesso!" });
            }
            catch (KeyNotFoundException)
            {
                return Json(new { success = false, message = "Animal não encontrado." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnimal(long id)
        {
            try
            {
                await _animalService.DeleteAnimalAsync(id);
                return Json(new { success = true, message = "Animal deletado com sucesso!" });
            }
            catch (KeyNotFoundException)
            {
                return Json(new { success = false, message = "Animal não encontrado." });
            }
        }

    }
}
