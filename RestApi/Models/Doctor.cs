using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Doctor : Person
    {
        [Column(TypeName = "date")]
        public DateTime DateEntryOffice { get; set; }
        public string? Email { get; set; }

        public Doctor()
        { 
        }

        public Doctor(int id, string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city, DateTime dateEntryOffice, string email)
            : base(id, firstName, lastName, birthdate, gender, city)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
        }
    }
}
