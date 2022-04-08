using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    public class PatientProvider : IPatientProvider
    {
        private readonly ILogger<PatientProvider> _logger;
        private readonly IPatientRepository _patientRepository;

        public PatientProvider(IPatientRepository patientRepository, ILogger<PatientProvider> logger)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            Patient patient;
            try
            {
                patient = await _patientRepository.GetPatientById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (patient == null || patient == default)
            {
                _logger.LogInformation($"Product with id: {id} could not be found.");
                throw new NotFoundException($"Product with id: {id} could not be found.");
            }
            return patient;
        }
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            IEnumerable<Patient> patients;

            try
            {
                patients = await _patientRepository.GetPatientsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            return patients;
        }
        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            if (patient.Email == null)
            {
                _logger.LogError("Patient must have an email field.");
                throw new BadRequestException("Patient must have an email field");
            }

            // CHECK TO MAKE SURE THE USE EMAIL IS NOT TAKEN
            Patient existingPatient;

            try
            {
                existingPatient = await _patientRepository.GetPatientByEmailAsync(patient.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingPatient != default)
            {
                _logger.LogError("Email is taken.");
                throw new ConflictException("Email is taken");
            }

            // set timestamp for patient
            patient.DateCreated = DateTime.UtcNow;
            patient.DateModified = DateTime.UtcNow;

            Patient savedPatient;

            try
            {
                savedPatient = await _patientRepository.CreatePatientAsync(patient);
                _logger.LogInformation("Patient Created.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedPatient;

        }
    }
}
