using Acme.Data.Entities;
using System;
using System.Collections.Generic;

namespace Acme.Data
{
    public interface IAcmeRepository
    {
        IEnumerable<Person> GetAllPersons();
        IEnumerable<Person> GetPersonById(Guid id);
        bool SaveAll();
    }
}