using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCData123.Controllers
{
    public class IDCitiesController : Controller
    {
        private readonly PersonContext _personContext;

        public IDCitiesController(PersonContext personContext)
        {
            _personContext = personContext;

        }
        public IActionResult Index()
        {
            List<City> ListOfCities = _personContext.Cities.ToList();
            foreach (City ci in ListOfCities)
            {
                var models = _personContext.Persons.Where(p => p.CurrentCityID == ci.Id);
                ci.Citizens = models.ToList();

                ci.CurrentCountry = _personContext.Countries.Find(ci.CurrentCountryID);
            }

            return View("Index", ListOfCities);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Countries"] = new SelectList(_personContext.Countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CityAdd(City city)
        {
            if (ModelState.IsValid)
            {

                {
                    _personContext.Cities.Add(city);
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDCities");
        }


        [HttpPost]
        public IActionResult Details(City cityValue)
        {
            City city = _personContext.Cities.Find(cityValue.Id);

            if (city != null)
            {
                var citizens = _personContext.Persons.Where(pm => pm.CurrentCityID == city.Id);
                city.Citizens = citizens.ToList();
                city.CurrentCountry = _personContext.Countries.Find(city.CurrentCountryID);

                ViewData["Countries"] = new SelectList(_personContext.Countries, "Id", "Name");
            }

            return View("Details", city);
        }

        [HttpPost]
        public IActionResult CityEdit(City city)
        {
            if (ModelState.IsValid)
            {


                var updateCity = _personContext.Cities.FirstOrDefault(item => item.Id == city.Id);

                if (updateCity != null)
                {
                    updateCity.Name = city.Name;
                    updateCity.CurrentCountryID = city.CurrentCountryID;
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDCities");
        }

        [HttpPost]
        public IActionResult Delete(City city)
        {

            var itemToRemove = _personContext.Cities.SingleOrDefault(r => r.Id == city.Id);
            if (itemToRemove != null)
            {
                _personContext.Cities.Remove(itemToRemove);
                _personContext.SaveChanges();
            }
            return RedirectToAction("Index", "IDCities");
        }
    }
}
