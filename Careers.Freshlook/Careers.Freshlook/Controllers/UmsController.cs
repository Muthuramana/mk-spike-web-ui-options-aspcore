using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careers.Freshlook.Models;
using Careers.Freshlook.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Careers.Freshlook.Controllers
{
    public class UmsController : Controller
    {
        private readonly IUnderstandMySelfService understandMySelfService;
        private const string SessionKey = "sessionId";
        public UmsController(IUnderstandMySelfService understandMySelfService)
        {
            this.understandMySelfService = understandMySelfService;
        }

        private string GetSessionId
        {
            get
            {
                var value = HttpContext.Session.GetString(SessionKey);
                if (string.IsNullOrEmpty(value))
                {
                    value = HttpContext.Session.Id;
                    HttpContext.Session.SetString(SessionKey, value);
                }
                return value;
            }
        }

        [Route("[controller]/{stepNumber}")]
        public async Task<IActionResult> Index(int stepNumber)
        {
            var model = new StepViewModel
            {
                Content = await understandMySelfService.GetStepDetails(stepNumber, GetSessionId)
            };

            return View(model);
        }

        [Route("[controller]/result")]
        public async Task<IActionResult> Index()
        {
            var model = new StepViewModel
            {
                Content = await understandMySelfService.GetResults(GetSessionId)
            };

            return View(model);
        }


        [HttpPost("[controller]/{stepNumber}")]
        public async Task<IActionResult> Index(StepAnswer stepAnswer)
        {
            var result = await understandMySelfService.SaveStepDetails(stepAnswer);

            if (result.IndexOf("results", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                return new RedirectResult("/ums/result");
            }
            var nextstep = stepAnswer.QuestionId + 1;
            return new RedirectResult($"/ums/{nextstep}");
        }

    }
}