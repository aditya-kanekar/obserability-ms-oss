using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PatientManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private PatientContext _context;
        private readonly ILogger<PatientController> _logger;

        private IConfiguration _configuration;

        public PatientController(ILogger<PatientController> logger, PatientContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _context.Patients;
        }

        [HttpPost]
        public async Task Create(Patient patient)
        {
            Patient newPatient = new Patient
            {
                Id = Guid.NewGuid(),
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                City = patient.City,
                Gender = patient.Gender
            };

            _context.Patients.Add(newPatient);
            if (!string.IsNullOrEmpty(patient.Allergies))
            {
                Allergy allergies =  new Allergy();
                allergies.PatientId = newPatient.Id;
                allergies.Name=patient.Allergies;

                String allergyApi = $"{_configuration.GetValue<string>("AppSettings:AllergyAPI")}/AllergyApi";
                using (var client = new HttpClient())
                {

                    HttpResponseMessage response = await client.PostAsJsonAsync(allergyApi, allergies);

                    if (response.IsSuccessStatusCode)
                    {
                        _context.SaveChanges();
                    }
                }
            }

        }

        // [HttpPut]
        // public IHttpActionResult Update(Patient patient)
        // {
        //     var patientTobeUpdated = this.patients.Where(p=>p.id == patient.id).SingleOrDefault();
        //     if(patientTobeUpdated == null)
        //     {
        //         return StatusCode(StatusCodes.Status404NotFound);
        //     }

        // }

    }
}
