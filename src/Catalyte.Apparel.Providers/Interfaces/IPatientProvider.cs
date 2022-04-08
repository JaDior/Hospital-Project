using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IPatientProvider
    {
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> CreatePatientAsync(Patient patient);
    }
}
