using Acme.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Acme.Data
{
    public class AcmeContext : DbContext
    {
        public AcmeContext(DbContextOptions<AcmeContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        // how to map entities with the db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IPerson>()
            //    .HasData(new IPerson()
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = "Pascal",
            //        LastName = "Siakim",
            //        Email = "pascal@siakim.com",
            //        Activity = "Escape Room",
            //        Comment = "Yay!"
            //    });
        }
    }
}
