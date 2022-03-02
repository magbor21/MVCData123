using Microsoft.AspNetCore.Mvc;
using MVCData123.Data;
using MVCData123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using React;

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


        public List<CityReactModel> ListCities() 
        {
            var cityList = _personContext.Cities.ToList();
            var cityReactList = new List<CityReactModel>();
            foreach (var item in cityList)
            {
                cityReactList.Add(new CityReactModel(item.Id, item.Name));
            }
            return cityReactList;
        }

        public List<PersonReactModel> GetPeopleDetails() //List people witd city and languages
        {
            var personList = _personContext.Persons.ToList();
            var personReactList = new List<PersonReactModel>();

            foreach (PersonModel pm in personList)
            {
                var languageReactList = new List<LanguageReactModel>();
                pm.CurrentCity = _personContext.Cities.Find(pm.CurrentCityID);
                pm.PersonLanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == pm.Id).ToList();
                foreach(var personLanguage in pm.PersonLanguages )
                {
                    Language lang = _personContext.Languages.Find(personLanguage.LanguageId);
                    languageReactList.Add(new LanguageReactModel(lang.Id, lang.Name));
                }
                personReactList.Add(new PersonReactModel(pm.Id.ToString(), pm.Name, pm.Phone, pm.CurrentCity.Name, pm.CurrentCity.Id.ToString(), languageReactList));
            }
            return personReactList;
        }


        [HttpGet]
        public IActionResult ListPeople()
        {
            ReactModel reactModel = new ReactModel();
            reactModel.ReactPeople = GetPeopleDetails();

            reactModel.ReactCities = ListCities();

            return Json(reactModel);
        }

        [HttpPost]
        public IActionResult DeletePerson([FromBody] PersonReactModel deletePerson)
        {
            var person = _personContext.Persons.Find(Int32.Parse(deletePerson.Id));
            if (deletePerson.Id == null)
            {
                return NotFound();
            }
            _personContext.Remove(person);
            _personContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonReactModel newPerson)
        {
            if (ModelState.IsValid)
            {
                PersonModel person = new PersonModel { Name = newPerson.Name, /*Id = Int32.Parse(newPerson.Id),*/ Phone = newPerson.Phone, CurrentCityID = Int32.Parse(newPerson.CityId) };

                _personContext.Persons.Add(person);
                _personContext.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }
    }



}
