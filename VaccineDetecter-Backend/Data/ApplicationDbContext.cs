using Microsoft.EntityFrameworkCore;
using VaccineDetecter_Backend.Models;

namespace VaccineDetecter_Backend.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MedicalTest> Tests { get; set; }
    }
}
