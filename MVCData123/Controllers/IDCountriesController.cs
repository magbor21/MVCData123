using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVCData123.Controllers
{
    public class IDCountriesController : Controller
    {
        private readonly PersonContext _personContext;

        public IDCountriesController(PersonContext personContext)
        {
            _personContext = personContext;

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Country> ListOfCountries = _personContext.Countries.ToList();
            foreach (Country co in ListOfCountries)
            {
                var cities = _personContext.Cities.Where(ci => ci.CurrentCountryID == co.Id);
                co.Cities = cities.ToList();
            }
            return View("Index", ListOfCountries);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View(); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CountryAdd(Country country)
        {
            if (ModelState.IsValid)
            {
             
                {
                    _personContext.Countries.Add(country);
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction( "Index", "IDCountries");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(Country countryValue)
        {
            Country country = _personContext.Countries.Find(countryValue.Id);

            if (country != null)
            {
                var cities = _personContext.Cities.Where(ci => ci.CurrentCountryID == country.Id);
                country.Cities = cities.ToList();
            }

            return PartialView("Details", country);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CountryEdit(Country country)
        {
            if (ModelState.IsValid)
            {


                var updateCountry = _personContext.Countries.FirstOrDefault(item => item.Id == country.Id);

                if (updateCountry != null)
                {
                    updateCountry.Name = country.Name;
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDCountries");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Country country)
        {

            var itemToRemove = _personContext.Countries.SingleOrDefault(r => r.Id == country.Id);
            if (itemToRemove != null)
            {
                _personContext.Countries.Remove(itemToRemove);
                _personContext.SaveChanges();
            }
            return RedirectToAction("Index", "IDCountries");
        }
    }
}
