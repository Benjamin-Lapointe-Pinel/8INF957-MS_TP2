using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KnnLibrary;

namespace RestApi.Models
{
    public class Patient : Person
    {
        public int DoctorId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
        [JsonIgnore]
        public ICollection<DiagnosticDB> DiagnosticDBs { get; set; } = new List<DiagnosticDB>();

        public Patient() { }

        public Patient(int id, string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city, Doctor doctor)
            : base(id, firstName, lastName, birthdate, gender, city)
        {
            DoctorId = doctor.Id;
            Doctor = doctor;
        }
    }
}
