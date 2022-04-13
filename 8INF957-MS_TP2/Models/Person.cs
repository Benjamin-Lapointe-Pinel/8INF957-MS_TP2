using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _8INF957_MS_TP2
{
    public class Person
    {
        private bool v;
        private bool diagnostic;

        public enum GenderEnum
        {
            Man,
            Woman
        }

        public int Id { get; set; }
        [Required(ErrorMessage="Champs Requis!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Champs Requis!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Champs Requis!")]
        public DateOnly Birthdate { get; set; }
        [Required(ErrorMessage = "Champs Requis!")]
        public GenderEnum Gender { get; set; }
        [Required(ErrorMessage = "Champs Requis!")]
        public string City { get; set; }

        public virtual bool IsValid => !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(City);

        public Person(int id)
        {
            FirstName = "";
            LastName = "";
            Birthdate = DateOnly.FromDateTime(DateTime.Now);
            Gender = GenderEnum.Man;
        }

        public Person(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            City = city;
        }

        public Person(bool v, bool diagnostic)
        {
            this.v = v;
            this.diagnostic = diagnostic;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }

        
    }
}
