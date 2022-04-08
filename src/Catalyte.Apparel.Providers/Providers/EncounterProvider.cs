using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Encounters;
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
    public class EncounterProvider : IEncounterProvider
    {
        private readonly ILogger<EncounterProvider> _logger;
        private readonly IEncounterRepository _encounterRepository;

        public EncounterProvider(IEncounterRepository encounterRepository, ILogger<EncounterProvider> logger)
        {
            _logger = logger;
            _encounterRepository = encounterRepository;
        }

        public async Task<IEnumerable<Encounter>> GetEncountersByPatientIdAsync(int id)
        {
            IEnumerable<Encounter> encounters;

            try
            {
                encounters = await _encounterRepository.GetEncountersByPatientId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            return encounters;
        }
        public async Task<Encounter> CreateEncounterAsync(Encounter encounter, int id )
        {
            // set timestamp and patient id for encounter
            encounter.DateCreated = DateTime.UtcNow;
            encounter.DateModified = DateTime.UtcNow;
            encounter.PatientId = id;

            Encounter savedEncounter;

            try
            {
                savedEncounter = await _encounterRepository.CreateEncounterAsync(encounter);
                _logger.LogInformation("Encounter Created.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedEncounter;
        }

        public async Task<Encounter> UpdateEncounterAsync(Encounter encounter, int id, int encounterId)
        {
            Encounter existingEncounter;

            try
            {
                existingEncounter = await _encounterRepository.GetEncounterById(encounterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingEncounter == default || existingEncounter.Id != encounterId)
            {
                _logger.LogInformation($"Encounter with id: {encounterId} does not exist.");
                throw new NotFoundException($"Encounter with id:{encounterId} not found.");
            }
            existingEncounter.PatientId = id;
            existingEncounter.Notes = encounter.Notes;
            existingEncounter.VisitCode = encounter.VisitCode;
            existingEncounter.Provider = encounter.Provider;
            existingEncounter.BillingCode = encounter.BillingCode;
            existingEncounter.ICD10 = encounter.ICD10;
            existingEncounter.TotalCost = encounter.TotalCost;
            existingEncounter.CoPay = encounter.CoPay;
            existingEncounter.ChiefComplaint = encounter.ChiefComplaint;
            existingEncounter.Pulse = encounter.Pulse;
            existingEncounter.SystolicPressure = encounter.SystolicPressure;
            existingEncounter.DiastolicPressure = encounter.DiastolicPressure;
            existingEncounter.DateCreated = encounter.DateCreated;
            existingEncounter.DateModified = DateTime.UtcNow;
            try
            {
                await _encounterRepository.UpdateEncounterAsync(existingEncounter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return existingEncounter;
        }
    }
}
