using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    public interface IEncounterRepository
    {
        Task<IEnumerable<Encounter>> GetEncountersByPatientId(int id);
        Task<Encounter> CreateEncounterAsync(Encounter encounter);
        Task<Encounter> GetEncounterById(int id);
        Task<Encounter> UpdateEncounterAsync(Encounter encounter);
    }
}
