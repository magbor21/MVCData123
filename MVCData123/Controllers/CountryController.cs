using Microsoft.AspNetCore.Mvc;
using MVCData123.Data;
using MVCData123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Controllers
{
    public class CountryController : Controller
    {
        private readonly PersonContext _personContext;

        public CountryController(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListCountries()
        {
            List<Country> ListOfCountries = _personContext.Countries.ToList();
            return PartialView("_countriesEFPartial", ListOfCountries);
        }

        [HttpPost]
        public IActionResult CountryAdd(Country country)
        {
            if (ModelState.IsValid)
            {
                _personContext.Countries.Add(country);
                _personContext.SaveChanges();
            }
            return View("Country");
        }
    }
}
