using Microsoft.AspNetCore.Mvc;

namespace RefugioAnimal.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
