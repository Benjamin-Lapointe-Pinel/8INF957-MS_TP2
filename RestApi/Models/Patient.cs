using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Patient : Person
    {
        public string? lastname { get; set; }
        public bool Diagnostic { get; set; } = false;

        public Patient()
        { 
            
        }

        public Patient(int id, string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city, bool diagnostic = false)
            : base(id, firstName, lastName, birthdate, gender, city)
        {
            Diagnostic = diagnostic;
        }
    }
}
