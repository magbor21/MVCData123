using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Models;


namespace MVCData123.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Ajax()
        {
            PersonMemory personMemory = new PersonMemory();
            //if(personMemory.Count < 1) troubleshooting
                personMemory.Repopulate(); //Adds a few people to work with 

            return View();
        }

        [HttpGet]
        public IActionResult ListPeople()
        {      
            PersonMemory personMemory = new PersonMemory();
            
            return PartialView("_limitedPeoplePartial", personMemory);
        }

        [HttpPost]
        public IActionResult PersonDetails(int personID)
        {
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson = personMemory.Read(personID);
            return PartialView("_personDetailsPartial", targetPerson);

        }

        [HttpPost]
        public IActionResult PersonDelete(int personID)
        {
            PersonMemory personMemory = new PersonMemory();
            bool success = personMemory.Delete(personID);

            if (success)
            {
                return StatusCode(200);
            }
            return StatusCode(404);

        }

    }

}
