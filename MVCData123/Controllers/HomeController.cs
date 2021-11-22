using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Models;

namespace MVCData123.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {                      
            ViewBag.headline = "Welcome to my page";
            ViewBag.text = "Click on People in the menu above to get started";
           
            return View();
        }
    }
}
