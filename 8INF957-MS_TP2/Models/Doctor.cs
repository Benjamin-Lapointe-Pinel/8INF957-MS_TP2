using System.ComponentModel.DataAnnotations.Schema;

namespace _8INF957_MS_TP2.Models
{
    
    
        public class Doctor : Person 
        {
        public Doctor(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, string city) : base(firstName, lastName, birthdate, gender, city)
        {
        }

        [Column(TypeName = "date")]
        public DateTime DateEntryOffice { get; set; }
        public string? lastName { get; set; }
        public string? FirstName { get; set; }
        public bool? GenderEnum { get; set; }
        public string? ville { get; set; }

        public string? Email { get; set; }
        

        public ICollection<Patient> Patients{ get; set; }


        static void AddDoctor(Models.Doctor doctor)
        {
            //TP2Context tP2Context = new TP2Context();
            //TP2Context.Doctors.Add(doctor);
            //TP2Context.saveChanges();
        }
  
    }
     
    
}
