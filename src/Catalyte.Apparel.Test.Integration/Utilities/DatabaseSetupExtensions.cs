using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Model;
using System;

namespace Catalyte.Apparel.Test.Integration.Utilities
{
    public static class DatabaseSetupExtensions
    {
        public static void InitializeDatabaseForTests(this ApparelCtx context)
        {
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
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public static void ReinitializeDatabaseForTests(this ApparelCtx context)
        {
            context.Patients.RemoveRange(context.Patients);
            context.InitializeDatabaseForTests();
        }
    }
}
