using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careers.Freshlook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Careers.Freshlook.Controllers
{
    public class JobProfileController : Controller
    {
        [Route("[controller]/{id}")]
        public IActionResult Index(string id)
        {
            return View(new JobProfileViewModel
            {
                Sections = new List<JobProfileSectionViewModel>
                {
                    new JobProfileSectionViewModel
                    {
                        Heading = "How to become",
                        Content = "<p>something</p>",
                        Order = 1
                    },
                    new JobProfileSectionViewModel
                    {
                        Heading = "Current oppurtunity",
                        Content = GetOppurtunity(),
                        Order = 2
                    }
                }.OrderBy(o => o.Order)
            });
        }

        public string GetOppurtunity()
        {
            return @"<div class=""grid - row"" id=""appGeneric"">
                              <div class=""column-full"">
                                <h3 class=""heading-medium"">
                                    Apprenticeships
                                    <span class=""heading-secondary"">In England</span>
                                </h3>
                            </div>
                            <div class=""column-half"">
                                <div class=""panel panel-border-narrow opportunity-item"">
                                    <h4 class=""heading-small"">
                                        <a href = ""https://www.findapprenticeship.service.gov.uk/apprenticeship/reference/91076335"" > Technical Support Apprentice REF: LS200a</a>
                                    </h4>
                                    <ul class=""list"">
                                        <li><span class=""bold-small"">Wage:</span> £166.50</li>
                                        <li><span class=""bold-small"">Location:</span> Chesterfield S41 8NE</li>
                                    </ul>
                                </div>
                            </div>
                            <div class=""column-half"">
                                <div class=""panel panel-border-narrow opportunity-item"">
                                    <h4 class=""heading-small"">
                                        <a href = ""https://www.findapprenticeship.service.gov.uk/apprenticeship/reference/1395162"" > IT Apprentice</a>
                                    </h4>
                                    <ul class=""list"">
                                        <li><span class=""bold-small"">Wage:</span> £11,658.00</li>
                                        <li><span class=""bold-small"">Location:</span> Newbury RG14 3BG</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class=""dfc-code-jp-vacancyText"">
                            <p>
                                <a href = ""https://www.findapprenticeship.service.gov.uk/apprenticeshipsearch"" > Find apprenticeships near you</a>
                            </p>
                        </div>

                        <div class=""grid-row dfc-code-jp-trainingCourse"">
                            <div class=""column-full"">
                                <h3 class=""heading-medium"">
                                    Training courses
                                    <span class=""heading-secondary"">In England</span>
                                </h3>
                            </div>
                        </div>
                        <div class=""dfc-code-jp-NoTrainingCoursesText"">
                            <p>
                            </p><p>Are you interested in becoming a software developer?</p>
                            <p>Search for <a href = ""https://dev.nationalcareersservice.org.uk/course-directory/home"" ></ a >< a href=""https://dev.nationalcareersservice.org.uk/course-directory/home"">training courses near you</a>.</p>
                            <div></div>
                            <p></p>
                        </div>";
        }
    }
}