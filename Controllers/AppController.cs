using Acme.Data;
using Acme.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

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
                string apiUrl = "http://localhost:8888";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var jsonContent = JsonConvert.SerializeObject(model);
                    var response = client.PostAsync("/api/persons",
                        new StringContent(jsonContent, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();

                    if (!response.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }

                ModelState.Clear();
            }

            return RedirectToAction("Listing");
        }

        [HttpGet("listing")]
        public IActionResult Listing()
        {
            var results = _repository.GetAllPersons().OrderBy(x => x.FirstName);

            return View(results);
        }
    }
}
