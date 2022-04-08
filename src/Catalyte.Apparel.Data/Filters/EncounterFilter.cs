using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Filters
{
    public static class EncounterFilter
    {
        public static IQueryable<Encounter> WhereEncounterPatientIdEquals(this IQueryable<Encounter> encounters, int patientId)
        {
            return encounters.Where(e => e.PatientId == patientId).AsQueryable();
        }
    }
}
