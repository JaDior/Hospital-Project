using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Encounters;
using Catalyte.Apparel.DTOs.Patients;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    [ApiController]
    [Route("/patients")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientProvider _patientProvider;
        private readonly IEncounterProvider _encounterProvider;
        private readonly IMapper _mapper;

        public PatientController(
            ILogger<PatientController> logger,
            IPatientProvider patientProvider,
            IEncounterProvider encounterProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _patientProvider = patientProvider;
            _encounterProvider = encounterProvider;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatientsAsync()
        {
            _logger.LogInformation("Request received for GetPatientsAsync");
            var patients = await _patientProvider.GetPatientsAsync();
            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> PatientById(int id)
        {
            _logger.LogInformation("Request received for PatientById");

            var patient = await _patientProvider.GetPatientById(id);
            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return Ok(patientDTO);
        }
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> CreateUserAsync([FromBody] Patient patientToCreate)
        {
            _logger.LogInformation("Request received for CreateUserAsync");

            var patient = await _patientProvider.CreatePatientAsync(patientToCreate);
            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return Created("/patient", patientDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatientAsync(int id, [FromBody] PatientDTO patientToUpdate)
        {
            _logger.LogInformation("Request received for update product");

            var patient = _mapper.Map<Patient>(patientToUpdate);
            var updatedPatient = await _patientProvider.UpdatePatientAsync(id, patient);
            var patientDTO = _mapper.Map<PatientDTO>(updatedPatient);

            return Ok(patientDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatientByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for DeletePatientByIdAsync for id: {id}");

            await _patientProvider.DeletePatientAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/encounters")]
        public async Task<ActionResult<IEnumerable<EncounterDTO>>> GetEncountersByPatientIdAsync(int id)
        {
            _logger.LogInformation("Request received for GetEncounterByPatientIdAsync");
            var encounters = await _encounterProvider.GetEncountersByPatientIdAsync(id);
            var encounterDtos = _mapper.Map<IEnumerable<EncounterDTO>>(encounters);
            return Ok(encounterDtos);
        }
        [HttpPost("{id}/encounters")]
        public async Task<ActionResult<EncounterDTO>> CreateEncounterAsync([FromBody] Encounter encounterToCreate, int id)
        {
            _logger.LogInformation("Request recieved for CreateEncounterAsync");
            var encounter = await _encounterProvider.CreateEncounterAsync(encounterToCreate, id);
            var encounterDTO = _mapper.Map<EncounterDTO>(encounter);

            return Created("/patient/{id}/encounters", encounterDTO);
        }
        [HttpPut("{id}/encounters/{encounterId}")]
        public async Task<ActionResult> UpdateEncounterAsync(int id, [FromBody] EncounterDTO encounterToUpdate, int encounterId)
        {
            _logger.LogInformation("Request received for update product");

            var encounter = _mapper.Map<Encounter>(encounterToUpdate);
            var updatedEncounter = await _encounterProvider.UpdateEncounterAsync(encounter, id, encounterId);
            var encounterDTO = _mapper.Map<EncounterDTO>(updatedEncounter);

            return Ok(encounterDTO);
        }
    }
}
