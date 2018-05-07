using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public class JobProfileService : IJobProfileService
    {
        private readonly IJobProfileSynopsisService jobProfileSynopsisService;
        private readonly IHowToBecomeService howToBecomeService;
        private readonly ISkillsService skillsService;
        private readonly IWhatYouWillDoService whatYouWillDoService;
        private readonly ICareerPathService careerPathService;
        private readonly ICurrentOppurtunitiesService currentOppurtunitiesService;
        private readonly ISalaryService salaryService;
        private readonly IWorkingPatternsService workingPatternsService;

        public JobProfileService(
            IJobProfileSynopsisService jobProfileSynopsisService,
            IHowToBecomeService howToBecomeService, 
            ISkillsService skillsService,
            IWhatYouWillDoService whatYouWillDoService,
            ICareerPathService careerPathService,
            ICurrentOppurtunitiesService currentOppurtunitiesService,
            ISalaryService salaryService,
            IWorkingPatternsService workingPatternsService
            )
        {
            this.jobProfileSynopsisService = jobProfileSynopsisService;
            this.howToBecomeService = howToBecomeService;
            this.skillsService = skillsService;
            this.whatYouWillDoService = whatYouWillDoService;
            this.careerPathService = careerPathService;
            this.currentOppurtunitiesService = currentOppurtunitiesService;
            this.salaryService = salaryService;
            this.workingPatternsService = workingPatternsService;
        }


        public async Task<IEnumerable<JobProfileSection>> GetSectionsAsync(string id)
        {
            var list = new List<JobProfileSection>
            {
                new JobProfileSection
                {
                    Heading = "How to become",
                    Content = await howToBecomeService.GetHowToBecomeAsync(id),
                    Order = 1
                },
                new JobProfileSection
                {
                    Heading = "Current oppurtunity",
                    Content = await currentOppurtunitiesService.GetCurrentOppurtunitiesAsync(id),
                    Order = 2
                }
            };

            return await Task.FromResult(list);
        }

        public async Task<string> GetHeroBannerAsync(string id)
        {
            return await GetHeroBannerContentAsync(id);
        }

        private async Task<string> GetHeroBannerContentAsync(string id)
        {
            var synopsis = await jobProfileSynopsisService.GetSynopsisAsync(id);
            var workingHoursAndPatterns = await workingPatternsService.GetWorkingHoursAndPatterns(id);

            return $@"<div class=""grid-row"">
            <div class=""column-desktop-two-thirds"">
                <h1 class=""heading-xlarge"">{synopsis.Title}</h1>
                <h2 class=""heading-secondary"">{string.Join(",", synopsis.AlternativeTitles)}</h2>
                <p>{synopsis.Overview}</p>
            </div>
        </div>
        <div class=""grid-row"">
            <div id=""Salary"" class=""column-40 job-profile-heroblock"">
                <h4>
                    Average salary
                    <span>(per year)</span>
                </h4>
                <div class=""job-profile-salary job-profile-heroblock-content"">
                    <h5 class=""dfc-code-jpsstarter"">{await salaryService.GetStarterSalaryAsync(id):C}<span>Starter</span></h5>
                    <h5 class=""dfc-code-jpsexperienced"">{await salaryService.GetExperiencedSalaryAsync(id):C}<span>Experienced</span></h5>
                </div>
            </div>
            <div id=""WorkingHours"" class=""column-30 job-profile-heroblock"">
                <h4>Typical hours <span></span></h4>
                <div class=""job-profile-hours job-profile-heroblock-content"">
                    <h5 class=""dfc-code-jphours"">{workingHoursAndPatterns.TypicalWorkingHours}<span class=""dfc-code-jpwhoursdetail"">{workingHoursAndPatterns.WorkingHoursDetail}</span></h5>
                </div>
            </div>
        </div>";
        }
        
    }
}
