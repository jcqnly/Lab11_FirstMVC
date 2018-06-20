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
            return View();
        }

        [HttpPost]
        public IActionResult Index(int beginYear, int endYear)
        {
            return RedirectToAction("Results", new { newBeginYear = beginYear, newEndYear = endYear });
        }

        //redirect user to another page
        public IActionResult Results(int newBeginYear, int newEndYear)
        {
            ViewData["Message"] = "Person Of The Year";
            Person person = new Person();

            return View(Person.GetPersons(newBeginYear, newEndYear));
        }
    }
}
