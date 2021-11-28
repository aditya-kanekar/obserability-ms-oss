using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AllergyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllergyApiController : ControllerBase
    {
        AllergyContext _context;
        private readonly ILogger<AllergyApiController> _logger;

        public AllergyApiController(ILogger<AllergyApiController> logger, AllergyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Allergy> Get(Guid patientId)
        {
            return this._context.Allergies.Where(a=> a.PatientId == patientId);
        }

        [HttpPost]
        public void Create(Allergy allergies)
        {
            this._context.Allergies.AddRange(allergies);
            this._context.SaveChanges();
        }
    }
}
