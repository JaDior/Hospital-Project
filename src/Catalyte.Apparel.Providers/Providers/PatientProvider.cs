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
        private readonly IEncounterRepository _encounterRepository;

        public PatientProvider(ILogger<PatientProvider> logger, IPatientRepository patientRepository, IEncounterRepository encounterRepository)
        {
            _logger = logger;
            _patientRepository = patientRepository;
            _encounterRepository = encounterRepository;
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
        public async Task<Patient> UpdatePatientAsync(int id, Patient updatedPatient)
        {
            // UPDATES Product
            Patient existingPatient;

            try
            {
                existingPatient = await _patientRepository.GetPatientById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingPatient == default || existingPatient.Id != id)
            {
                _logger.LogInformation($"Patient with id: {id} does not exist.");
                throw new NotFoundException($"Patient with id:{id} not found.");
            }
            Patient patientWithMatchingEmail;
            try
            {
                patientWithMatchingEmail = await _patientRepository.GetPatientByEmailAsync(updatedPatient.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (patientWithMatchingEmail != null)
            {
                _logger.LogError("Email is taken.");
                throw new ConflictException("Email is taken");
            }
            existingPatient.First_Name = updatedPatient.First_Name;
            existingPatient.Last_Name = updatedPatient.Last_Name;
            existingPatient.SSN = updatedPatient.SSN;
            existingPatient.Email = updatedPatient.Email;
            existingPatient.Street = updatedPatient.Street;
            existingPatient.City = updatedPatient.City;
            existingPatient.State = updatedPatient.State;
            existingPatient.ZipCode = updatedPatient.ZipCode;
            existingPatient.Age = updatedPatient.Age;
            existingPatient.Height = updatedPatient.Height;
            existingPatient.Insurance = updatedPatient.Insurance;
            existingPatient.Gender = updatedPatient.Gender;
            existingPatient.DateCreated = updatedPatient.DateCreated;
            existingPatient.DateModified = DateTime.UtcNow;
            try
            {
                await _patientRepository.UpdatePatientAsync(existingPatient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return existingPatient;
        }

        public async Task DeletePatientAsync(int id)
        {
            IEnumerable<Encounter> patientEncounters;
            try
            {
                patientEncounters = await _encounterRepository.GetEncountersByPatientId(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (patientEncounters.Count() != 0)
            {
                _logger.LogInformation($"Patient with id: {id} has encounters.");
                throw new ConflictException($"Patient with id:{id} has encounters.");
            }
            Patient patientToDelete;
            try
            {
                patientToDelete = await _patientRepository.GetPatientById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            if (patientToDelete == null)
            {
                _logger.LogInformation($"Patient with id: {id} does not exist");
                throw new NotFoundException($"Patient with id: {id} does not exist");
            }
            await _patientRepository.DeletePatientAsync(patientToDelete);
        }
    }
}
