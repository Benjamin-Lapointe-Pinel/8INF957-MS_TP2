using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            [Display(Name = "Homme")]
            Man,
            [Display(Name = "Femme")]
            Woman
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
        public GenderEnum Gender { get; set; }
        [Required(ErrorMessage = "Champ requis!")]
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
