using Acme.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Data
{
    public class AcmeRepository : IAcmeRepository
    {
        private readonly AcmeContext _context;
        private readonly ILogger<AcmeRepository> _logger;

        public AcmeRepository(AcmeContext context, ILogger<AcmeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            try
            {
                _context.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add entity : {ex}");
            }
        }

        public IEnumerable<Person> GetAllPersons()
        {
            try
            {
                return _context.Persons.OrderBy(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all persons: {ex}");
                return null;
            }
        }

        public Person GetPersonById(Guid id)
        {
            try
            {
                return _context.Persons.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get person with id '{id}' [{ex}]");
                return null;
            }
        }

        public bool SaveAll()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save changes : {ex}");
                return false;
            }
        }
    }
}
