using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;

namespace MVCData123.Controllers
{
    public class IDPeopleController : Controller
    {
        private readonly PersonContext _personContext;

        public IDPeopleController(PersonContext personContext)
        {
            _personContext = personContext;

        }
        public IActionResult Index()
        {
            List<PersonModel> ListOfPerson = _personContext.Persons.ToList();
            foreach (PersonModel pm in ListOfPerson)
            {
                pm.CurrentCity = _personContext.Cities.Find(pm.CurrentCityID);
                pm.PersonLanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == pm.Id).ToList(); // Uses personLanguage for counting
            }
            return View("Index", ListOfPerson);
        }
    }
}
