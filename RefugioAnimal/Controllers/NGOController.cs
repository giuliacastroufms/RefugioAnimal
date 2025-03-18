using Microsoft.AspNetCore.Mvc;

namespace RefugioAnimal.Controllers
{
    public class NGOController : Controller
    {
        public IActionResult NGOAndProtector()
        {
            return View();
        }

        public IActionResult Donations()
        {
            return View();
        }
    }
}
