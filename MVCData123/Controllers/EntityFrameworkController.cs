using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Models;
using MVCData123.Data;

namespace MVCData123.Controllers
{
    public class EntityFrameworkController : Controller
    {
        private readonly PersonContext _personContext;

        public EntityFrameworkController(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public IActionResult EntityFramework()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult ListPeople()
        {
            List<PersonModel> ListOfPerson = _personContext.Persons.ToList();
            return PartialView("_peopleEFPartial", ListOfPerson);
        }

        [HttpPost]
        public IActionResult PersonDelete(int personID)
        {

            var itemToRemove = _personContext.Persons.SingleOrDefault(r => r.Id == personID);
            if (itemToRemove != null)
            {            
                _personContext.Persons.Remove(itemToRemove);
                _personContext.SaveChanges();
                return StatusCode(200);
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult PersonAdd(PersonModel personModel)
        {
            if(ModelState.IsValid)
            {
                _personContext.Persons.Add(personModel);
                _personContext.SaveChanges();
            }
            return View("EntityFramework");
        }
    }
}
