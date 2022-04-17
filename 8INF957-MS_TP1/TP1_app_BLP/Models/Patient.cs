using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_app_BLP.Model;

namespace TP01_HeartDiseaseDiagnostic
{
    public class Patient : Person
    {
        public List<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();

        public Patient()
        {
        }

        public Patient(string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city)
            : base(firstName, lastName, birthdate, gender, city)
        {
        }
    }
}
