using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Filters;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    public class EncounterRepository : IEncounterRepository
    {
        private readonly IApparelCtx _ctx;

        public EncounterRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Encounter>> GetEncountersByPatientId(int patientId)
        {
            return await _ctx.Encounters.AsQueryable().WhereEncounterPatientIdEquals(patientId).ToListAsync();
        }
        public async Task<Encounter> CreateEncounterAsync(Encounter encounter)
        {
            _ctx.Encounters.Add(encounter);
            await _ctx.SaveChangesAsync();

            return encounter;
        }
        public async Task<Encounter> GetEncounterById(int id)
        {
            return await _ctx.Encounters.FindAsync(id);
        }
        public async Task<Encounter> UpdateEncounterAsync(Encounter encounter)
        {
            _ctx.Encounters.Update(encounter);
            await _ctx.SaveChangesAsync();

            return encounter;
        }
    }
}
