using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimePersonOfTheYear.Models;


namespace TimePersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        //default action for the controller
        public IActionResult Index()
        {
            //instantiate each person


            //Collections initializer
            List<Person> timePerson = 
                new List<Person> { };

            return View(timePerson);
        }

        //redirect user to another page
        public IActionResult Class()
        {
            return RedirectToAction();
        }
    }
}
