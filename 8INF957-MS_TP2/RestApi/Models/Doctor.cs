using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Champ requis!")]
        [Column(TypeName = "date")]
        public DateTime DateEntryOffice { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public string? Email { get; set; }
        public ConfigurationIa ConfigurationIa { get; set; }
        [JsonIgnore]
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

        public Doctor()
        {
             ConfigurationIa = new ConfigurationIa(1, "euclidean");
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
