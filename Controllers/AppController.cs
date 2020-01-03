using Acme.Data;
using Acme.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Acme.Controllers
{
    public class AppController : Controller
    {
        private readonly IAcmeRepository _repository;

        public AppController(IAcmeRepository repository)
        {
           _repository = repository;
        }

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
            var results = _repository.GetAllPersons().OrderBy(x => x.Id);

            return View(results);
        }
    }
}
