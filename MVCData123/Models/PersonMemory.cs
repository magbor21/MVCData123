using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class PersonMemory // New Model for the Uppgift3
    {
        public static List<Person> Personlist = new List<Person>(); 

        public int Count { get { return Personlist.Count; } }
        public List<Person> Read()
        {
            return Personlist;
        }

        public Person Read(int id)
        {
            Person targetPerson = Personlist.Find(c => c.PersonId == id);
            return targetPerson;
        }

        public bool Delete(int id)
        {
            var itemToRemove = Personlist.SingleOrDefault(r => r.PersonId == id);
            if (itemToRemove != null)
            {
                return Personlist.Remove(itemToRemove);
            }

            return false;

        }

        public Person Create(string Name, string City, string Phone)
        {
            Person newPerson = new Person(Name,Phone,City);
            Personlist.Add(newPerson);
            return newPerson;
        }

        public void Repopulate()
        
        {
            PersonMemory personMemory = new PersonMemory();
            personMemory.Create("Pelle Svensson","Stockholm","08-1234567");
            personMemory.Create("Pelle Svanslös", "Uppsala", "018-555666");
            personMemory.Create("Pelle Saltkråka", "Saltkråkan", "070-9876321");

            personMemory.Create("Adam Davidsson","Göteborg","031-170920");
            personMemory.Create("Bertil Eriksson", "Halmstad", "035-133772");
            personMemory.Create("Caesar Filipsson", "Indal", "060-987464");

            personMemory.Create("Öyvind Audi", "Verkstaden", "010-1010101");
            personMemory.Create("Kalle Volvo", "Skroten", "099-999999");
            personMemory.Create("Audi Bil", "Utomlands", "+46703011271");

            personMemory.Create("Jake Peralta", "Brooklyn","9-9");
            personMemory.Create("Charles Boyle", "Brooklyn", "9-9");
            personMemory.Create("Terry Jeffords", "Brooklyn", "9-9");



        }


    }
}
