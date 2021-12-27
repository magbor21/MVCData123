using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Models;
using MVCData123.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCData123.Controllers
{
    public class EntityFrameworkController : Controller
    {
        private readonly PersonContext _personContext;

        public EntityFrameworkController(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PeopleS()
        {
            ViewData["Cities"] = new SelectList(_personContext.Cities, "Id", "Name");
            
            return View("People");
        }

        public IActionResult Cities()
        {
            ViewData["Countries"] = new SelectList(_personContext.Countries, "Id", "Name");
            return View();
        }

        public IActionResult Countries()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListPeople()
        {
            List<PersonModel> ListOfPerson = _personContext.Persons.ToList();
            foreach(PersonModel pm in ListOfPerson)
            {               
                pm.CurrentCity = _personContext.Cities.Find(pm.CurrentCityID);
            }
            return PartialView("_peopleEFPartial", ListOfPerson);
        }


        [HttpGet]
        public IActionResult ListCountries()
        {
            List<Country> ListOfCountries = _personContext.Countries.ToList();
            foreach (Country co in ListOfCountries)
            {
                co.Cities = (IEnumerable<City>)_personContext.Cities.Where<City>(ci => ci.CurrentCountryID == co.Id);
            }
            return PartialView("_countriesEFPartial", ListOfCountries);
        }

        [HttpGet]
        public IActionResult ListCities()
        {
            List<City> ListOfCities = _personContext.Cities.ToList();
            foreach (City ci in ListOfCities)
            {
                ci.Citizens = (IEnumerable<PersonModel>)_personContext.Persons.Where(p => p.CurrentCityID == ci.Id);
                ci.CurrentCountry = _personContext.Countries.Find(ci.CurrentCountryID);
            }

            return PartialView("_citiesEFPartial", ListOfCities);
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
            return View("People");
        }

        [HttpPost]
        public IActionResult CityDelete(int cityID)
        {

            var itemToRemove = _personContext.Cities.SingleOrDefault(r => r.Id == cityID);
            if (itemToRemove != null)
            {
                _personContext.Cities.Remove(itemToRemove);
                _personContext.SaveChanges();
                return StatusCode(200);
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult CityAdd(City city)
        {
            if (ModelState.IsValid)
            {
                _personContext.Cities.Add(city); 
                _personContext.SaveChanges();
            }
            return View("Cities");
        }

        [HttpPost]
        public IActionResult CountryDelete(int countryID)
        {

            var itemToRemove = _personContext.Countries.SingleOrDefault(r => r.Id == countryID);
            if (itemToRemove != null)
            {
                _personContext.Countries.Remove(itemToRemove);
                _personContext.SaveChanges();
                return StatusCode(200);
            }
            return StatusCode(404);
        }

            [HttpPost]
        public IActionResult CountryAdd(Country country)
        {
            if (ModelState.IsValid)
            {
                _personContext.Countries.Add(country);
                _personContext.SaveChanges();
            }
            return View("Countries");
        }
    }
}
