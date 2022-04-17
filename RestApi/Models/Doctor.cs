using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RestApi.Services;

namespace RestApi.Models
{
    public class Doctor : Person
    {
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateEntryOffice { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

        public Doctor()
        { 
        }

        public Doctor(int id, string username, string password, string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city, DateTime dateEntryOffice, string email)
            : base(id, firstName, lastName, birthdate, gender, city)
        {
            Username = username;
            Password = password;
            DateEntryOffice = dateEntryOffice;
            Email = email;
        }
    }
}
