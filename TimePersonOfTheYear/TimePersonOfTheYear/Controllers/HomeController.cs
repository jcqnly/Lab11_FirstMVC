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
        /// <summary>
        /// Directs the user to the index page, where the the years
        /// can be selected.  This sends off a get request for data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// The years chosen will be sent to this method, which then makes 
        /// a post requests, with the specified parameters.  The return
        /// directs the user to the Results view
        /// </summary>
        /// <param name="beginYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(int beginYear, int endYear)
        {
            return RedirectToAction("Results", new { newBeginYear = beginYear, newEndYear = endYear });
        }

        /// <summary>
        /// This dislays the results from the search query on the results page
        /// </summary>
        /// <param name="newBeginYear"></param>
        /// <param name="newEndYear"></param>
        /// <returns></returns>
        public IActionResult Results(int newBeginYear, int newEndYear)
        {
            ViewData["Message"] = "Person Of The Year";
            Person person = new Person();

            return View(Person.GetPersons(newBeginYear, newEndYear));
        }
    }
}
