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
    public class PatientRepository : IPatientRepository
    {
        private readonly IApparelCtx _ctx;

        public PatientRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Patient> GetPatientById(int patientId)
        {
            return await _ctx.Patients.FindAsync(patientId);
        }
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _ctx.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatientByEmailAsync(string email)
        {
            return await _ctx.Patients.AsQueryable().WherePatientEmailEquals(email).SingleOrDefaultAsync();
        }
        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            _ctx.Patients.Add(patient);
            await _ctx.SaveChangesAsync();

            return patient;
        }
    }
}
