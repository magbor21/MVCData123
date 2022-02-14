using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;

namespace MVCData123.Controllers
{
    public class IDLanguagesController : Controller
    {
        private readonly PersonContext _personContext;

        public IDLanguagesController(PersonContext personContext)
        {
            _personContext = personContext;

        }
        public IActionResult Index()
        {

            List<Language> ListOfLanguages = _personContext.Languages.ToList();

            foreach (Language l in ListOfLanguages)
            {
                var personLanguages = _personContext.PersonLanguages.Where(pl => pl.LanguageId == l.Id);
                l.PersonLanguages = personLanguages.ToList();
            }

            return View("Index", ListOfLanguages);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LanguageAdd(Language language)
        {
            if (ModelState.IsValid)
            {

                {
                    _personContext.Languages.Add(language);
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDLanguages");
        }

        [HttpPost]
        public IActionResult Details(Language languageValue)
        {
            Language language = _personContext.Languages.Find(languageValue.Id);

            if (language != null)
            {
                var persons = _personContext.Persons
                                .Where(p => p.PersonLanguages
                                .Any(pl => pl.LanguageId == language.Id));

                language.Persons = persons.ToList();

            }

            return View("Details", language);
        }


        [HttpPost]
        public IActionResult LanguageEdit(Language language)
        {
            if (ModelState.IsValid)
            {


                var updateLanguage = _personContext.Languages.FirstOrDefault(item => item.Id == language.Id);

                if (updateLanguage != null)
                {
                    updateLanguage.Name = language.Name;
                    _personContext.SaveChanges();
                }
            }
            return RedirectToAction("Index", "IDLanguages");
        }

        [HttpPost]
        public IActionResult Delete(Language language)
        {

            var itemToRemove = _personContext.Languages.SingleOrDefault(r => r.Id == language.Id);
            if (itemToRemove != null)
            {
                _personContext.Languages.Remove(itemToRemove);
                _personContext.SaveChanges();
            }
            return RedirectToAction("Index", "IDLanguages");
        }
    }
}
