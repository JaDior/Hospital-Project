using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientById(int patientId);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByEmailAsync(string email);
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
    }
}
