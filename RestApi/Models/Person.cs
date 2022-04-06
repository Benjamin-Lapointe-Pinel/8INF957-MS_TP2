using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Person
    {
        public enum GenderEnum
        {
            Man,
            Woman
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }
        public GenderEnum Gender { get; set; }
        public string? City { get; set; }

        public Person()
        { 
        }

        public Person(int id, string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            City = city;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }        
    }
}
