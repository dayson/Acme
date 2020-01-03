using Acme.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Data
{
    public class AcmeRepository : IAcmeRepository
    {
        private readonly AcmeContext _context;

        public AcmeRepository(AcmeContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.OrderBy(x => x.Id).ToList();
        }

        public IEnumerable<Person> GetPersonById(Guid id)
        {
            return _context.Persons.Where(x => x.Id == id).ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
