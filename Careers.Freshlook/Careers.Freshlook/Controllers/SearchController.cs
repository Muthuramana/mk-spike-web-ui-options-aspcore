using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careers.Freshlook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Careers.Freshlook.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            //Search micro service?
            return View(new SearchViewModel
            {
                LabelText = "Enter a job title",
                AutoCompleteMinimumCharacters = 3,
                MaximumNumberOfDisplayedSuggestions = 5,
                UseFuzzyAutoCompleteMatching = true
            });
        }
    }
}