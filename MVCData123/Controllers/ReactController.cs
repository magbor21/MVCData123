using Microsoft.AspNetCore.Mvc;
using MVCData123.Data;
using MVCData123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Controllers
{
    public class ReactController : Controller
    {
        private readonly PersonContext _personContext;

        public ReactController(PersonContext personContext)
        {
            _personContext = personContext;

        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("listPeople")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ListPeople()
        {
            List<PersonModel> ListOfPerson = _personContext.Persons.ToList();
            List<PersonReactModel> ListOfPeople = new List<PersonReactModel>();
            foreach (PersonModel pm in ListOfPerson)
            {
                pm.CurrentCity = _personContext.Cities.Find(pm.CurrentCityID);
                ListOfPeople.Add(new PersonReactModel { Id = pm.Id, Name = pm.Name, Phone = pm.Phone, CityID = pm.CurrentCityID, CityName = pm.CurrentCity.Name });
            }
            
            return Json(ListOfPeople);
        }

    }
    

    
}
