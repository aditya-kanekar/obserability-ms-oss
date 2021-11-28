using Microsoft.EntityFrameworkCore;

namespace AllergyApi
{
    public class AllergyContext : DbContext
    {
        public DbSet<Allergy> Allergies { get; set; }
        public AllergyContext(DbContextOptions<AllergyContext> context) : base(context)
        {

        }
    }
}