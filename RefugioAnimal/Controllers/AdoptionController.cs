using Microsoft.AspNetCore.Mvc;
using RefugioAnimal.Services;

namespace RefugioAnimal.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly AdoptionService _adoptionService;

        public AdoptionController(AdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
