﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP01_HeartDiseaseDiagnostic
{
    public class Person
    {
        public enum GenderEnum
        {
            Man,
            Woman
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public GenderEnum Gender { get; set; }
        public string City { get; set; }

        public virtual bool IsValid => !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(City);

        public Person()
        {
            FirstName = "";
            LastName = "";
            Birthdate = DateTime.Now;
            Gender = GenderEnum.Man;
        }

        public Person(string firstName, string lastName, DateTime birthdate, GenderEnum gender, string city)
        {
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
