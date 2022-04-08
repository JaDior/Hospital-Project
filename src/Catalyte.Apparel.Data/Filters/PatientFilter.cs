using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Filters
{
    public static class PatientFilter
    {
        public static IQueryable<Patient> WherePatientEmailEquals(this IQueryable<Patient> patients, string email)
        {
            return patients.Where(p => p.Email == email).AsQueryable();
        }
    }
}
