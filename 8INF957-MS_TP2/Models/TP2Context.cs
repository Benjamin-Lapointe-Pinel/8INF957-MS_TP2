using Microsoft.EntityFrameworkCore;
using _8INF957_MS_TP2.Models;
using static _8INF957_MS_TP2.Person;


namespace _8INF957_MS_TP2.Models
{
    public class TP2Context : DbContext
    {
        public DbSet <Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;database=tp2;user=tp2_user;password=tp2_password;";
            dbContextOptionsBuilder.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString));
        }
       
    }
}
