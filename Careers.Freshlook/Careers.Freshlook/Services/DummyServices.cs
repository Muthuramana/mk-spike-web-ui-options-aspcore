using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    //private readonly IJobProfileSynopsisService jobProfileSynopsisService;
    //private readonly IHowToBecomeService howToBecomeService;
    //private readonly ISkillsService skillsService;
    //private readonly IWhatYouWillDoService whatYouWillDoService;
    //private readonly ICareerPathService careerPathService;
    //private readonly ICurrentOppurtunitiesService currentOppurtunitiesService;
    //private readonly ISalaryService salaryService;
    //private readonly IWorkingPatternsService workingPatternsService;
    public class DummyServices : ICurrentOppurtunitiesService, ISalaryService
    {
        public async Task<string> TryGetCurrentOppurtunitiesAsync(string id)
        {
            return string.Empty;
            //return await Task.FromResult(@"<div class=""grid - row"" id=""appGeneric"">
            //                  <div class=""column-full"">
            //                    <h3 class=""heading-medium"">
            //                        Apprenticeships
            //                        <span class=""heading-secondary"">In England</span>
            //                    </h3>
            //                </div>
            //                <div class=""column-half"">
            //                    <div class=""panel panel-border-narrow opportunity-item"">
            //                        <h4 class=""heading-small"">
            //                            <a href = ""https://www.findapprenticeship.service.gov.uk/apprenticeship/reference/91076335"" > Technical Support Apprentice REF: LS200a</a>
            //                        </h4>
            //                        <ul class=""list"">
            //                            <li><span class=""bold-small"">Wage:</span> £166.50</li>
            //                            <li><span class=""bold-small"">Location:</span> Chesterfield S41 8NE</li>
            //                        </ul>
            //                    </div>
            //                </div>
            //                <div class=""column-half"">
            //                    <div class=""panel panel-border-narrow opportunity-item"">
            //                        <h4 class=""heading-small"">
            //                            <a href = ""https://www.findapprenticeship.service.gov.uk/apprenticeship/reference/1395162"" > IT Apprentice</a>
            //                        </h4>
            //                        <ul class=""list"">
            //                            <li><span class=""bold-small"">Wage:</span> £11,658.00</li>
            //                            <li><span class=""bold-small"">Location:</span> Newbury RG14 3BG</li>
            //                        </ul>
            //                    </div>
            //                </div>
            //                <div class=""dfc-code-jp-vacancyText"">
            //                    <p>
            //                        <a href = ""https://www.findapprenticeship.service.gov.uk/apprenticeshipsearch"">Find apprenticeships near you</a>
            //                    </p>
            //                </div>
            //            </div>
            //            <div class=""grid-row dfc-code-jp-trainingCourse"">
            //                <div class=""column-full"">
            //                    <h3 class=""heading-medium"">
            //                        Training courses
            //                        <span class=""heading-secondary"">In England</span>
            //                    </h3>
            //                </div>
            //                <div class=""dfc-code-jp-NoTrainingCoursesText"">
            //                    <p>Are you interested in becoming a software developer?</p>
            //                    <p>Search for <a href = ""https://dev.nationalcareersservice.org.uk/course-directory/home"" ></a><a href=""https://dev.nationalcareersservice.org.uk/course-directory/home"">training courses near you</a>.</p>
            //                </div>
            //            </div>");
        }

        public async Task<int> GetExperiencedSalaryAsync(string id)
        {
            return await Task.FromResult(45000);
        }

        public async Task<string> GetHowToBecomeAsync(string id)
        {
            return await Task.FromResult(@"<p>You could:</p>
                    <ul>
                        <li>do an apprenticeship</li>
                        <li>do a degree</li>
                        <li>teach yourself</li>
                    </ul>
                    <p>Whichever way you go, you'll usually need 4 or 5 GCSEs including English and maths at grades 9 to 4 (A* to C) <a href=""https://www.gov.uk/what-different-qualification-levels-mean/list-of-qualification-levels"">or equivalent qualifications</a>, plus some programming ability or a strong interest in the subject.</p>
                    <h3>Apprenticeship</h3>
                    <p>You could do an <a href=""https://www.gov.uk/apprenticeships-guide/overview"">advanced apprenticeship as a software development technician</a>. </p>
                    <p>It will usually take 12 to 18 months. </p>
                    <p>You can then move onto a higher apprenticeship as a s<a href=""https://www.findapprenticeship.service.gov.uk/apprenticeshipsearch"">oftware developer</a>. This can take between 1 and 4 years.</p>
                    <h3>College or university</h3>
                    <p>You could do a foundation degree, higher national diploma (HND) or a degree in a subject like:</p>
                    <ul>
                        <li>computer science</li>
                        <li>information technology</li>
                        <li>software development</li>
                        <li>software engineering</li>
                        <li>maths</li>
                        <li>business information systems</li>
                    </ul>
                    <p>UCAS has information on <a href=""https://www.ucas.com"">degree courses and entry requirements</a>.</p>
                    <p>You can apply for <a href=""https://www.gov.uk/further-education-courses/financial-help"">student finance to cover fees and living costs for higher education</a>.</p>
                    <p>Full-time courses at university usually take 3 years. College and HND courses take 2 years full time.</p>
                    <p>Find a <a href=""https://nationalcareersservice.direct.gov.uk/course-directory/home"">college course near you</a>.</p>
                    <p>You may be able to get <a href=""https://www.gov.uk/further-education-courses/financial-help"">financial help to study at college</a>. </p>
                    <h3>Home study</h3>
                    <p>Many software developers teach themselves and there are many free online learning resources available.</p>
                    <p>Particularly if you have taught yourself, companies will look to see if you are someone who understands programming languages and frameworks, project management and software development methods.</p>
                    <p>The Chartered Institute for IT (BCS) has <a href=""http://www.bcs.org"">more information about training and qualifications</a>.</p>");
        }

        public async Task<int> GetStarterSalaryAsync(string id)
        {
            return await Task.FromResult(25000);
        }

        //public async Task<JobProfileSynopsis> GetSynopsisAsync(string id)
        //{
        //    return await Task.FromResult(new JobProfileSynopsis
        //    {
        //        Title = "Software developer",
        //        AlternativeTitles = new string[] { "Programmer", "software engineer" },
        //        Overview = "Develop or create software"
        //    });
        //}

        public async Task<WorkingHoursAndPatterns> GetWorkingHoursAndPatternsAsync(string id)
        {
            return await Task.FromResult(new WorkingHoursAndPatterns
            {
                TypicalWorkingHours = "35 to 40",
                WorkingHoursDetail = "Flexible",
                WorkingPattern = "Usually 9 to 5, flexible Evenings and Weekends"
            });
        }
    }
}
