using AutoMapper;
using Careers.Freshlook.Models;
using Careers.Freshlook.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Controllers
{
    public class JobProfileController : Controller
    {
        private readonly IJobProfileService jobProfileService;
        private readonly IMapper mapper;

        public JobProfileController(IJobProfileService jobProfileService, IMapper mapper)
        {
            this.jobProfileService = jobProfileService;
            this.mapper = mapper;
        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var jp = await jobProfileService.GetSectionsAsync(id);
            var jpVm = mapper.Map<IEnumerable<JobProfileSection>, IEnumerable<JobProfileSectionViewModel>>(jp);

            ViewData["Title"] = await jobProfileService.GetPageTitleAsync(id);

            return View(new JobProfileViewModel
            {
                HeroBannerContent = await jobProfileService.GetHeroBannerAsync(id),
                Sections = jpVm.OrderBy(o => o.Order)
            });
        }
    }
}