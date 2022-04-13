using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _8INF957_MS_TP2.Models
{
    
    
        public class Doctor : Person 
        {
        public Doctor(string firstName, string lastName, DateOnly birthdate, DateOnly DateEn , GenderEnum gender, string city)
            : base( firstName, lastName, birthdate, gender, city)
        {
        }
        [Required(ErrorMessage="Chapms requis !")]
        [Column(TypeName = "date")]
        //[Required(ErrorMessage = "Chapms requis !")]
        public  DateOnly birthdate { get; set; }
        [Required(ErrorMessage = "Chapms requis !")]
        public DateTime DateEntryOffice { get; set; }
        [Required(ErrorMessage = "Chapms requis !")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Chapms requis !")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Chapms requis !")]
        public bool? GenderEnum { get; set; }
        [Required(ErrorMessage = "Chapms requis !")]
        public string? city { get; set; }
        [Required(ErrorMessage = "Chapms requis !")]
        public string? email { get; set; }
        

        public ICollection<Patient> Patients{ get; set; }


      
  
    }
     
    
}
