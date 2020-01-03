using System;

namespace Acme.Data.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Activity { get; set; }
        public string Comment { get; set; }
    }
}
