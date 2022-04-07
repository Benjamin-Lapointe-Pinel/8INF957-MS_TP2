using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestApi.Models.Person;

namespace RestApi.Models.DTO
{
    public class PatientDTO : PersonDTO
    {
        public bool Diagnostic { get; set; } = false;

        public PatientDTO(string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city, bool diagnostic = false)
            : base(firstName, lastName, birthdate, gender, city)
        {
            Diagnostic = diagnostic;
        }
    }
}
