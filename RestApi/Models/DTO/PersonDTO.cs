using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static RestApi.Models.Person;

namespace RestApi.Models.DTO
{
    public class PersonDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public GenderEnum Gender { get; set; }
        public string City { get; set; }

        public PersonDTO(string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            City = city;
        }   
    }
}
