using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVCData123.Models
{

    public static class PersonEnumerator //Adds unique numbers starting with 1 000 001
    {
        
            private static int personId = 1000000;

            public static int NextPersonId() // Adds 1 to personID and returns it
            {
                return ++personId;
            }
    }

    public class Person
    {
        public int PersonId { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public static List<Person> ListOfPeople = new List<Person>(); // Static list. Master copy of people
        public static string Sortby { get; set; }
        public static bool Asc { get; set; }


        public Person(string Name, string Phone, string City) // A constructor, if you want one
        {
            this.Name = Name;
            this.Phone = Phone;
            this.City = City;
            this.PersonId = PersonEnumerator.NextPersonId();

        }


        public static void GeneratePeople() // some people to start with
        {
            ListOfPeople.AddRange(new List<Person> {
                    new Person("Kalle Banan","0123-454562","Örebro"),
                    new Person("Anna Book", "040-5102456","Kullavik"),
                    new Person("Leif Pettersson","031-170920", "Göteborg") });
        } 

        public static bool DeleteById(int idNumber) // Find and delete the person (idNumber is a hidden field in the table)
        {
            var itemToRemove = ListOfPeople.SingleOrDefault(r => r.PersonId == idNumber);
            if (itemToRemove != null)
            {
                ListOfPeople.Remove(itemToRemove);
                return true;
            }

            return false;
        }
    }
}


