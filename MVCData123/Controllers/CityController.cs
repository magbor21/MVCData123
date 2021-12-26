using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;

namespace MVCData123.Controllers
{
    public class CityController : Controller
    {
        private readonly PersonContext _personContext;

        public CityController(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public IActionResult Index()
        {
            ViewData["Countries"] = new SelectList(_personContext.Countries, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult CityAdd()
        {

            return View();
        }
    }
}


