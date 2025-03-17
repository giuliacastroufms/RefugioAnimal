using Microsoft.AspNetCore.Mvc;

namespace RefugioAnimal.Controllers
{
    public class AdoptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
