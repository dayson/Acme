using Acme.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }

            return View();
        }

        [HttpGet("listing")]
        public IActionResult Listing()
        {
            return View();
        }
    }
}
