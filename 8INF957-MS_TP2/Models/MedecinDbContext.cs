using Microsoft.EntityFrameworkCore;

namespace _8INF957_MS_TP2.Models
{

    public class MedecinDbContext : DbContext
    {
        public MedecinDbContext( DbContextOptions <MedecinDbContext> options)
            :base(options)
        {

           
        }
        public DbSet <Patient> Patients { get; set; }
        public DbSet <Medecin> Medecins { get; set; }
    }
}
