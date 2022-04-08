using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.Data.Model;
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
        private readonly IMapper _mapper;

        public PatientController(
            ILogger<PatientController> logger,
            IPatientProvider patientProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _patientProvider = patientProvider;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetProductsAsync()
        {
            _logger.LogInformation("Request received for GetProductsAsync");
            var patients = await _patientProvider.GetPatientsAsync();
            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> PatientById(int id)
        {
            _logger.LogInformation("Request received for GetUserByEmailAsync");

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
    }
}
