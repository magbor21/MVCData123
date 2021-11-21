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
                Person.GeneratePeople();

            ViewBag.headline = "Welcome to my page";
            ViewBag.text = "Click on People in the menu above to get started";

            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.Persons = Person.ListOfPeople;

            return View(peopleViewModel);

        }

        [HttpPost]
        public IActionResult Delete(string ButtonDelete)
        {
            
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            if(ButtonDelete != null)
                Person.DeleteById(1000002);

            peopleViewModel.Persons = Person.ListOfPeople;

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult People(PeopleViewModel peopleViewModel)
        {

            if (ModelState.IsValid)
            {
                Person person; 
                peopleViewModel.person = new Person { Name = "olle", Phone = peopleViewModel.Phone, City = peopleViewModel.City, PersonId = PersonEnumerator.NextPersonId() };
                Person.ListOfPeople.Add(peopleViewModel.person);
            }

            //PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.Persons = Person.ListOfPeople;
            return View(peopleViewModel);

        }
    }
}
