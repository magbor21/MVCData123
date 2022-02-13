using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;

namespace MVCData123.Controllers
{
    public class IDUsersController : Controller
    {
        private readonly PersonContext _personContext;

        public IDUsersController(PersonContext personContext)
        {
            _personContext = personContext;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
