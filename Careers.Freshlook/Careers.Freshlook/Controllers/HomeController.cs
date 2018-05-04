using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Careers.Freshlook.Models;

namespace Careers.Freshlook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomePageViewModel
            {
                JobProfiles = new Dictionary<string, string>
                {
                    { "software-developer", "Software developer" },
                    { "plumber", "Plumber" },
                },
                LabelText = "Enter a job title",
                Id = "header-search"
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
