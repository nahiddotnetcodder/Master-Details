using MasterDetails.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetails.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
