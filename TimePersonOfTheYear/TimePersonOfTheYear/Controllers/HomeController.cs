using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimePersonOfTheYear.Models;
using TimePersonOfTheYear;


namespace TimePersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        //default action for the controller
        [HttpGet]
        public IActionResult Index()
        {
            //Collections initializer
            //List<Person> timePerson = new List<Person>();

            //timePerson = Person.GetPersons(1990, 2000);
            //return View(timePerson);
            return View();
        }

        [HttpPost]
        public IActionResult Index(int beginYear, int endYear)
        {
            return RedirectToAction("Results", new { beginYear, endYear });
        }

        //redirect user to another page
        public IActionResult Results(int beginYear, int endYear)
        {
            ViewData["Message"] = "Person Of The Year";
            Person person = new Person();

            return View(Person.GetPersons(beginYear, endYear));
        }
    }
}
