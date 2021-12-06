using Microsoft.AspNetCore.Mvc;
using MVCData123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult People()
        {
            if (Person.ListOfPeople.Count < 1)
                Person.GeneratePeople(); //Adds a few people to work with 

            Person.Sortby = "name"; //Initial settings for sorter
            Person.Asc = true;

            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            createPersonViewModel.pvm = new PeopleViewModel();
            createPersonViewModel.pvm.Persons = new List<Person>();
            createPersonViewModel.pvm.Persons = Person.ListOfPeople;

            return View("People", createPersonViewModel);

        }


        [HttpPost]
        public IActionResult DeleteID(CreatePersonViewModel createPersonViewModel)
        {
            if (createPersonViewModel.DeleteID != null) // Delete one
            {
                Person.ListOfPeople.Remove(Person.ListOfPeople.Find(x => x.PersonId.ToString().Equals(createPersonViewModel.DeleteID)));
                createPersonViewModel.pvm.Persons = Person.ListOfPeople;
            }
            return View("People",createPersonViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAll(CreatePersonViewModel createPersonViewModel)
        {
            if (createPersonViewModel.DeleteALL != null && createPersonViewModel.DeleteALL == "Yes") // or Delete all
            {
                Person.ListOfPeople.Clear();
                createPersonViewModel.pvm.Persons.Clear();
            }
            return View("People", createPersonViewModel);

        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {

            if (ModelState.IsValid) //Only adds if everything is filled in
            {
                createPersonViewModel.person = new Person(createPersonViewModel.Name, createPersonViewModel.Phone, createPersonViewModel.City);
                Person.ListOfPeople.Add(createPersonViewModel.person);
                
            }
            createPersonViewModel.pvm.Persons = Person.ListOfPeople;
            return View("People", createPersonViewModel);
        }

        [HttpPost]
        public IActionResult Search(CreatePersonViewModel createPersonViewModel)
        {

           
            createPersonViewModel.pvm.Persons = Person.ListOfPeople;

            if (createPersonViewModel.SearchTerm != null && createPersonViewModel.SearchTerm != "")
            {
                createPersonViewModel.pvm.Filter(createPersonViewModel.SearchTerm);
            }
            
            return View("People", createPersonViewModel);

        }

        [HttpPost]
        public IActionResult Sort(CreatePersonViewModel createPersonViewModel)
        {

            if (createPersonViewModel.SortBy != null) // It was easier to sort the list myself than to get the built in sorter to stop complaining.
            {
                Person.Sortby = createPersonViewModel.SortBy;
                createPersonViewModel.pvm.Persons = Person.ListOfPeople;
                switch (Person.Sortby)
                {
                    case "phone":
                        createPersonViewModel.pvm.SortPhone();
                        break;
                    case "city":
                        createPersonViewModel.pvm.SortCity();
                        break;
                    default:
                        createPersonViewModel.pvm.SortName();
                        break;
                }

            }

            return View("People", createPersonViewModel);

        }
    }
}
