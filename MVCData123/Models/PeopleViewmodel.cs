using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class PeopleViewModel
    {
        public List<Person> Persons = new List<Person>();
        public List<Person> Filter(string searchString)
        {
            List<Person> tempList = new List<Person>();
            foreach( Person p in Persons)
            {

                if (p.Name.Contains(searchString) || p.City.Contains(searchString) || p.Phone.Contains(searchString)) // Checks all fields for the search term
                    tempList.Add(p);
            }
            Persons = tempList;
            return tempList; //Replaces the old list with the new. The original people are safe in the Person.listOfPeople
            
        }

        public void SortName() /// sorts by name
        {
            if (Persons.Count < 2) // 1 or 0 = nothing to sort
                return;

            List<Person> tempList = new List<Person>();
            bool first = true;
            foreach(Person p in Persons)
            {
                if (first)
                {
                    tempList.Add(p); // You don't need to compare the first item with anything
                    first = false;
                    continue;
                }
                
                for(int i=0;i<=tempList.Count;i++)
                {
                    if (i == tempList.Count) //If you have checked all and ended up at the end of the list
                    {
                        tempList.Add(p); //Break doesn't break big enough
                        break;
                    }
                    if(p.Name.CompareTo(tempList[i].Name) < 1)
                    {
                        tempList.Insert(i,p); //Insert if you are smaller
                        break;
                    }                 

                }
                
            }

            Persons = tempList;

        }

        public void SortCity() //Same as above but for city
        {
            if (Persons.Count < 2)
                return;

            List<Person> tempList = new List<Person>();
            bool first = true;
            foreach (Person p in Persons)
            {
                if (first)
                {
                    tempList.Add(p);
                    first = false;
                    continue;
                }

                for (int i = 0; i <= tempList.Count; i++)
                {
                    if (i == tempList.Count)
                    {
                        tempList.Add(p); 
                        break;
                    }
                    if (p.City.CompareTo(tempList[i].City) < 1)
                    {
                        tempList.Insert(i, p);
                        break;
                    }

                }

            }

            Persons = tempList;

        }

        public void SortPhone() // And again, but for Phone
        {
            if (Persons.Count < 2)
                return;

            List<Person> tempList = new List<Person>();
            bool first = true;
            foreach (Person p in Persons)
            {
                if (first)
                {
                    tempList.Add(p);
                    first = false;
                    continue;
                }

                for (int i = 0; i <= tempList.Count; i++)
                {
                    if (i == tempList.Count)
                    {
                        tempList.Add(p); //Break doesn't break big enough
                        break;
                    }
                    if (p.Phone.CompareTo(tempList[i].Phone) < 1)
                    {
                        tempList.Insert(i, p);
                        break;
                    }

                }

            }

            Persons = tempList;

        }


    }

    
}
