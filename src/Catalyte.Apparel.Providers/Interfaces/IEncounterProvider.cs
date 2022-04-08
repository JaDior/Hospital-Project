using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IEncounterProvider
    {
        Task<IEnumerable<Encounter>> GetEncountersByPatientIdAsync(int id);
        Task<Encounter> CreateEncounterAsync(Encounter encounter, int id);
        Task<Encounter> UpdateEncounterAsync(Encounter encounter, int id, int encounterId);
    }
}
