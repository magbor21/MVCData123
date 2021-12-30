using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCData123.Data;
using MVCData123.Models;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Languages()
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
                pm.PersonLanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == pm.Id).ToList();
            }
            return PartialView("_peopleEFPartial", ListOfPerson);
        }


        [HttpGet]
        public IActionResult ListCountries()
        {
            List<Country> ListOfCountries = _personContext.Countries.ToList();
            foreach (Country co in ListOfCountries)
            {
                var cities = _personContext.Cities.Where(ci => ci.CurrentCountryID == co.Id);
                co.Cities = cities.ToList();
            }
            return PartialView("_countriesEFPartial", ListOfCountries);
        }

        [HttpGet]
        public IActionResult ListLanguages()
        {
            List<Language> ListOfLanguages = _personContext.Languages.ToList();
            
            foreach (Language l in ListOfLanguages)
            {
                var personLanguages = _personContext.PersonLanguages.Where(pl => pl.LanguageId == l.Id);
                l.PersonLanguages = personLanguages.ToList();
            }
            
            return PartialView("_languagesEFPartial", ListOfLanguages);
        }

        [HttpGet]
        public IActionResult ListCities()
        {
            List<City> ListOfCities = _personContext.Cities.ToList();
            foreach (City ci in ListOfCities)
            {
                var models = _personContext.Persons.Where(p => p.CurrentCityID == ci.Id);
                ci.Citizens = models.ToList();
                
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
            return RedirectToAction("PeopleS");
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
            return RedirectToAction("Cities");
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
        public IActionResult LanguageDelete(int languageID)
        {

            var itemToRemove = _personContext.Languages.SingleOrDefault(r => r.Id == languageID);
            if (itemToRemove != null)
            {
                _personContext.Languages.Remove(itemToRemove);
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

        [HttpPost]
        public IActionResult LanguageAdd(Language language)
        {
            if (ModelState.IsValid)
            {
                _personContext.Languages.Add(language);
                _personContext.SaveChanges();
            }
            return View("Languages");
        }

        [HttpPost]
        public IActionResult CountryDetails(int countryID)
        {
            Country country = _personContext.Countries.Find(countryID);

            if(country != null)
            {
                var cities = _personContext.Cities.Where(ci => ci.CurrentCountryID == country.Id);
                country.Cities = cities.ToList();
            }
            
            return PartialView("_countryDetailPartial", country);
        }

        [HttpPost]
        public IActionResult LanguageDetails(int languageID)
        {
            Language language = _personContext.Languages.Find(languageID);

            if (language != null)
            {
                var persons = _personContext.Persons
                                .Where(p => p.PersonLanguages
                                .Any(pl => pl.LanguageId == language.Id));

                language.Persons = persons.ToList();
               
            }

            return PartialView("_languageDetailPartial", language);
        }

        [HttpPost]
        public IActionResult CityDetails(int cityID)
        {
            City city = _personContext.Cities.Find(cityID);

            if (city != null)
            {
                var citizens = _personContext.Persons.Where(pm => pm.CurrentCityID == city.Id);
                city.Citizens = citizens.ToList();
                city.CurrentCountry = _personContext.Countries.Find(city.CurrentCountryID);
            }

            return PartialView("_cityDetailPartial", city);
        }

        [HttpPost]
        public IActionResult PersonDetails(int personID)
        {
            PersonModel personmodel = _personContext.Persons.Find(personID);

            if (personmodel != null)
            {
                personmodel.CurrentCity = _personContext.Cities.Find(personmodel.CurrentCityID);

                var personlanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == personmodel.Id).ToList();
                
                
                foreach(PersonLanguage p in personlanguages)
                {
                    p.Language = _personContext.Languages.Find(p.LanguageId);
                }

                personmodel.PersonLanguages = personlanguages;

                personmodel.Languages = _personContext.Languages.ToList();
                
            }

            return PartialView("_personEFDetailPartial", personmodel);
        }

        [HttpPost]

        public IActionResult PersonLanguageAdd(int PersonID, int LanguageID)
        {
            PersonLanguage pl = new PersonLanguage { PersonId = PersonID, LanguageId = LanguageID };
            
            try{
                _personContext.PersonLanguages.Add(pl);
                _personContext.SaveChanges();            
            }
            
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return StatusCode(404);
            }
            
            return StatusCode(200);         
            
        }
    }
}
