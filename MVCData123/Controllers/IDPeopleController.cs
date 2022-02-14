using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MVCData123.Controllers
{
    public class IDPeopleController : Controller
    {
        private readonly PersonContext _personContext;

        public IDPeopleController(PersonContext personContext)
        {
            _personContext = personContext;

        }
        public IActionResult Index()
        {
            List<PersonModel> ListOfPerson = _personContext.Persons.ToList();
            foreach (PersonModel pm in ListOfPerson)
            {
                pm.CurrentCity = _personContext.Cities.Find(pm.CurrentCityID);
                pm.PersonLanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == pm.Id).ToList(); // Uses personLanguage for counting
            }
            return View("Index", ListOfPerson);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Cities"] = new SelectList(_personContext.Cities, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult PersonAdd(PersonModel person)
        {
            if (ModelState.IsValid)
            {

                {
                    _personContext.Persons.Add(person);
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDPeople");
        }


        [HttpPost]
        public IActionResult Details(PersonModel personValue)
        {
            PersonModel personmodel = _personContext.Persons.Find(personValue.Id);
            
            if (personmodel != null)
            {
                personmodel.CurrentCity = _personContext.Cities.Find(personmodel.CurrentCityID);

                var personlanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == personmodel.Id).ToList();

                foreach (PersonLanguage p in personlanguages)
                {
                    p.Language = _personContext.Languages.Find(p.LanguageId);
                }

                personmodel.PersonLanguages = personlanguages;

                ViewData["Cities"] = new SelectList(_personContext.Cities, "Id", "Name");

            }

            return View("Details", personmodel);
        }

        [HttpPost]
        public IActionResult PersonEdit(PersonModel personmodel)
        {
            if (ModelState.IsValid)
            {

                var updatePerson = _personContext.Persons.FirstOrDefault(item => item.Id == personmodel.Id);

                if (updatePerson != null)
                {
                    updatePerson.Name = personmodel.Name;
                    updatePerson.CurrentCityID = personmodel.CurrentCityID;
                    updatePerson.Phone = personmodel.Phone;
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDPeople");
        }

        [HttpPost]
        public IActionResult Languages(PersonModel personValue)
        {
            PersonModel personmodel = _personContext.Persons.Find(personValue.Id);
            PersonLanguage personLanguage = new PersonLanguage();

            if (personmodel != null)
            {
                

                var personlanguages = _personContext.PersonLanguages.Where(pl => pl.PersonId == personmodel.Id).ToList();

                foreach (PersonLanguage p in personlanguages)
                {
                    p.Language = _personContext.Languages.Find(p.LanguageId);
                }

                personmodel.PersonLanguages = personlanguages;

                ViewData["Languages"] = new SelectList(_personContext.Languages, "Id", "Name");

                personLanguage.Person = personmodel;
            }

            return View("Languages", personLanguage);
        }


        [HttpPost]
        public IActionResult LanguageAdd(PersonLanguage pl)
        {
            try
            {
                _personContext.PersonLanguages.Add(pl);
                _personContext.SaveChanges();
            }

            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                
            }


            PersonModel personmodel = _personContext.Persons.Find(pl.PersonId);
            PersonLanguage personLanguage = new PersonLanguage();

            if (personmodel != null)
            {


                var personlanguages = _personContext.PersonLanguages.Where(pel => pel.PersonId == personmodel.Id).ToList();

                foreach (PersonLanguage p in personlanguages)
                {
                    p.Language = _personContext.Languages.Find(p.LanguageId);
                }

                personmodel.PersonLanguages = personlanguages;

                ViewData["Languages"] = new SelectList(_personContext.Languages, "Id", "Name");

                personLanguage.Person = personmodel;
            }

            return View("Languages", personLanguage); 
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult LanguageDelete(PersonLanguage pl)
        {
            var itemToDelete = _personContext.PersonLanguages.First(row => row.PersonId == pl.PersonId && row.LanguageId == pl.LanguageId);

            try
            {
                _personContext.PersonLanguages.Remove(itemToDelete);
                _personContext.SaveChanges();
            }

            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return StatusCode(404);
            }

            PersonModel personmodel = _personContext.Persons.Find(pl.PersonId);
            PersonLanguage personLanguage = new PersonLanguage();

            if (personmodel != null)
            {


                var personlanguages = _personContext.PersonLanguages.Where(pel => pel.PersonId == personmodel.Id).ToList();

                foreach (PersonLanguage p in personlanguages)
                {
                    p.Language = _personContext.Languages.Find(p.LanguageId);
                }

                personmodel.PersonLanguages = personlanguages;

                ViewData["Languages"] = new SelectList(_personContext.Languages, "Id", "Name");

                personLanguage.Person = personmodel;
            }

            return View("Languages", personLanguage);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(PersonModel personModel)
        {

            var itemToRemove = _personContext.Persons.SingleOrDefault(r => r.Id == personModel.Id);
            if (itemToRemove != null)
            {
                _personContext.Persons.Remove(itemToRemove);
                _personContext.SaveChanges();
                return RedirectToAction("Index", "IDPeople");
            }
            return StatusCode(404);
        }
    }
}