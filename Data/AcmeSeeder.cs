using Acme.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Acme.Data
{
    public class AcmeSeeder
    {
        private readonly AcmeContext _context;
        private readonly IWebHostEnvironment _hosting;

        public AcmeSeeder(AcmeContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Persons.Any())
            {
                // need to create sample data
                var filePath = Path.Combine(_hosting.ContentRootPath, "Data/listings.json");
                var json = File.ReadAllText(filePath);
                var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
                _context.Persons.AddRange(persons);

                _context.SaveChanges();
            }
        }
    }
}
