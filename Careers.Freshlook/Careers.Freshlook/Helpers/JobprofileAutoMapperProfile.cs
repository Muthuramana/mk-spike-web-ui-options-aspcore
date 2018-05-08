using AutoMapper;
using Careers.Freshlook.Models;
using Careers.Freshlook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Helpers
{
    public class JobprofileAutoMapperProfile : Profile
    {
        public JobprofileAutoMapperProfile()
        {
            CreateMap<JobProfileSection, JobProfileSectionViewModel>();
        }
    }
}
