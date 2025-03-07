using Microsoft.AspNetCore.Mvc;

namespace RefugioAnimal.Controllers
{
    public class NGOController : Controller
    {
        public async Task<IActionResult> NGOAndProtector()
        {
            return View();
        }

        public async Task<IActionResult> Donations()
        {
            return View();
        }
    }
}
