using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnnLibrary;

namespace RestApi.Models
{
    public class Patient : Person
    {
<<<<<<< HEAD
        public string? lastname { get; set; }
        public bool Diagnostic { get; set; } = false;
=======
        public ICollection<DiagnosticDB> DiagnosticDBs { get; set; }
>>>>>>> 7ff091c6fe18cc1143fde0543acd0665075e644d

        public Patient()
        { 
            
        }

        public Patient(int id, string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city)
            : base(id, firstName, lastName, birthdate, gender, city)
        {
        }
    }
}
