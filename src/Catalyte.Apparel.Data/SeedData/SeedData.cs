using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;

using Microsoft.EntityFrameworkCore;
using System;

namespace Catalyte.Apparel.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();

            modelBuilder.Entity<Product>().HasData(productFactory.GenerateRandomProducts(1000));
            
            var usersFactory = new UsersFactory();

            modelBuilder.Entity<User>().HasData(usersFactory.GenerateUsers(7));
            var patient = new Patient()
            {
               Id = 1,
               First_Name = "Mark",
               Last_Name = "Vanderwater",
               SSN = "123-23-1313",
               Email = "MVater@aol.com",
               Street = "Greene Ct",
               City = "Woodbrook",
               State = "IL",
               ZipCode = "60323",
               Age = 19,
               Height = "6'0",
               Weight = 173,
               Insurance = "Anetna",
               Gender = "Male",
               DateCreated = DateTime.UtcNow,
               DateModified = DateTime.UtcNow
    };
            modelBuilder.Entity<Patient>().HasData(patient);
        }
    }
    
}
