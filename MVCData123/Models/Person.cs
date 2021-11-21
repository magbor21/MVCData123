using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVCData123.Models
{

    public static class PersonEnumerator
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
        public static List<Person> ListOfPeople = new List<Person>();




        public static void GeneratePeople()
        {
            ListOfPeople.AddRange(new List<Person> {
                    new Person{Name = "Kalle", Phone = "123454562131",City = "Örebro", PersonId = PersonEnumerator.NextPersonId()},
                    new Person{Name = "Anna", Phone = "040-5102456",City = "Kullavik", PersonId = PersonEnumerator.NextPersonId()},
                    new Person{Name = "Leif", Phone = "031-170920", City = "Göteborg", PersonId = PersonEnumerator.NextPersonId()}});
        } 

        public static bool DeleteById(int idNumber)
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


