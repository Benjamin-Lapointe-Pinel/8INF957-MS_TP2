using KnnLibrary;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.Services;
using static RestApi.Models.Person;

namespace RestApi
{
    public class TP2Context : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiagnosticDB> Diagnostics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;database=tp2;user=tp2_user;password=tp2_password;";
            dbContextOptionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Patients)
                .WithOne(e => e.Doctor);
            modelBuilder.Entity<Patient>()
                .HasOne(e => e.Doctor)
                .WithMany(e => e.Patients);
            modelBuilder.Entity<Patient>()
                .HasMany(e => e.DiagnosticDBs)
                .WithOne(e => e.Patient);
            modelBuilder.Entity<DiagnosticDB>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.DiagnosticDBs);

            Doctor blp = new(1, "blp", AuthenticationService.HashPassword("blp", "abc123"), "Benjamin", "Lapointe-Pinel", new(1995, 11, 13), GenderEnum.Man, "Rimouski", new DateTime(), "blp@uqar.ca");
            Doctor zt = new(2, "zt", AuthenticationService.HashPassword("zt", "abc123"), "Zaid", "Tidjet", new(1995, 7, 5), GenderEnum.Man, "Rimouski", new DateTime(), "zt@uqar.ca");

            modelBuilder.Entity<Doctor>().HasData(blp, zt);
        }
    }
}
