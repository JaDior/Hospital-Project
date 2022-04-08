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
            var encounter = new Encounter()
            {
                Id = 1,
                PatientId = 1,
                Notes = "yellow eye whites",
                VisitCode = "D1R 3F6",
                Provider = "Anetna",
                BillingCode = "189.198.190-88",
                ICD10 = "D21",
                TotalCost = 1200.67,
                CoPay = 250,
                ChiefComplaint = "Headache, loss in peripheral vision",
                Pulse = 120,
                SystolicPressure =  96,
                DiastolicPressure = 72,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
            modelBuilder.Entity<Encounter>().HasData(encounter);
        }
    }
    
}
