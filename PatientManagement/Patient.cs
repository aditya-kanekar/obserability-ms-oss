using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagement
{
    public class Patient
    {
        public Guid Id {get; set;}
        public DateTime DateOfBirth { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String City {get;set;}
        [NotMapped]
        public string Allergies { get; set; }
       
    }

    public class Allergy
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; } 
    }
}
