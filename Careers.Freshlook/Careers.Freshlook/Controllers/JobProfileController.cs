using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Careers.Freshlook.Models;
using Careers.Freshlook.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> IndexAsync(string id)
        {
            var jp = jobProfileService.GetSectionsAsync(id);

            return View(new JobProfileViewModel
            {
                HeroBannerContent = await jobProfileService.GetHeroBannerAsync(id),
                Sections = mapper.Map<IEnumerable<JobProfileSectionViewModel>>(jp).OrderBy(o => o.Order)
            });
        }

    }
}