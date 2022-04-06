using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using static RestApi.Models.Person;

namespace RestApi
{
    public class TP2Context : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;database=tp2;user=tp2_user;password=tp2_password;";
            dbContextOptionsBuilder.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient(1, "Benjamin", "Lapointe-Pinel", new(1995, 11, 13), GenderEnum.Man, "Rimouski"),
                new Patient(2, "Zaid", "Tidjet", new(1995, 7, 5), GenderEnum.Man, "Rimouski"));
            modelBuilder.Entity<Doctor>().HasData(
               new Doctor(1, "Benjamin", "Lapointe-Pinel", new(1995, 11, 13), GenderEnum.Man, "Rimouski", new DateTime(), "blp@uqar.ca"),
               new Doctor(2, "Zaid", "Tidjet", new(1995, 7, 5), GenderEnum.Man, "Rimouski", new DateTime(), "zt@uqar.ca"));
        }
    }
}
