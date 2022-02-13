using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Models;
using MVCData123.Data;

namespace MVCData123.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonContext _personContext;

        public HomeController(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public IActionResult Index()
        {                      
            ViewBag.headline = "Welcome to my page";
            ViewBag.text = "Please login or register. ";
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.People =      _personContext.Persons.Count();
            homeViewModel.Cities =      _personContext.Cities.Count();
            homeViewModel.Countries =   _personContext.Countries.Count();
            homeViewModel.Languages =   _personContext.Languages.Count();
            homeViewModel.Users =       _personContext.Users.Count();

            return View("Index",homeViewModel);
        }
    }
}
