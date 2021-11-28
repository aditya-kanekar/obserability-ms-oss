using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AllergyApi
{
    public class Allergy
    {
        [Key]
        public Guid PatientId { get; set; }
        
        public string Name { get; set; }
    }
}