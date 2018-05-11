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
            short order = 1;
            var list = new List<JobProfileSection>
            {
                new JobProfileSection
                {
                    Heading = "How to become",
                    Content = await howToBecomeService.TryGetHowToBecomeAsync(id),
                    Order = order++,
                },
                new JobProfileSection
                {
                    Heading = "Skills required",
                    Content = await skillsService.TryGetSkillsRequiredAsync(id),
                    Order = order++,
                },
                new JobProfileSection
                {
                    Heading = "What you'll do",
                    Content = await whatYouWillDoService.TryGetWhatYouWillDoAsync(id),
                    Order = order++,
                },
                new JobProfileSection
                {
                    Heading = "Career path and progression",
                    Content = await careerPathService.TryGetCareerPathAndProgressionAsync(id),
                    Order = order++,
                },
                new JobProfileSection
                {
                    Heading = "Current oppurtunity",
                    Content = await currentOppurtunitiesService.TryGetCurrentOppurtunitiesAsync(id),
                    Order = order++,
                }
            };

            list.RemoveAll(s => string.IsNullOrEmpty(s.Content));
            return await Task.FromResult(list);
        }

        public async Task<string> GetHeroBannerAsync(string id)
        {
            return await GetHeroBannerContentAsync(id);
        }

        public async Task<string> GetPageTitleAsync(string id)
        {
            var synopsis = await jobProfileSynopsisService.GetSynopsisAsync(id);
            return synopsis.Title;
        }

        private async Task<string> GetHeroBannerContentAsync(string id)
        {
            var synopsis = await jobProfileSynopsisService.GetSynopsisAsync(id);
            var workingHoursAndPatterns = await workingPatternsService.GetWorkingHoursAndPatternsAsync(id);

            return $@"<div class=""grid-row"">
            <div class=""column-desktop-two-thirds"">
                <h1 class=""heading-xlarge"">{synopsis.Title}</h1>
                <h2 class=""heading-secondary"">{string.Join(", ", synopsis.AlternativeTitles)}</h2>
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
                    <h5 class=""dfc-code-jpsstarter"">{await salaryService.GetStarterSalaryAsync(id)}<span>Starter</span></h5>
                    <h5 class=""dfc-code-jpsexperienced"">{await salaryService.GetExperiencedSalaryAsync(id)}<span>Experienced</span></h5>
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
