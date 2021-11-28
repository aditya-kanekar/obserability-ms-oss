using System;
using Microsoft.EntityFrameworkCore;

namespace PatientManagement
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public PatientContext(DbContextOptions<PatientContext> context) : base(context)
        {

        }
    }

}