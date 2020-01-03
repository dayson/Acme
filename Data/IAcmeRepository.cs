using Acme.Data.Entities;
using System;
using System.Collections.Generic;

namespace Acme.Data
{
    public interface IAcmeRepository
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(Guid id);
        bool SaveAll();
        void AddEntity(object model);
    }
}