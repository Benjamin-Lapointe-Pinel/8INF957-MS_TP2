using System.ComponentModel.DataAnnotations;

namespace _8INF957_MS_TP2.Models
{
    public class Patient : Person
    {
        public ICollection<Doctor> Doctors { get; set; }
        public Patient(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, string city,string Diagnose) 
            : base(firstName, lastName, birthdate, gender, city)
        {
           
    }
        [Required(ErrorMessage="Champs Requis !")]
        public string? city { get; set; }
        [Required(ErrorMessage = "Champs Requis !")]
        public string? Diagnose { get; set; }



    }


}

