using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services.Models
{
    public class JobProfileServiceModel
    {
        public string Id { get; set; }
        public string UrlName { get; set; }
        public string Title { get; set; }
        public string AlternativeTitle { get; set; }
        public string Overview { get; set; }
        public string Salary { get; set; }
        public string Skills { get; set; }
        public string WhatYouWillDo { get; set; }
        public string WorkingHoursPatternsAndEnvironment { get; set; }
        public string CareerPathAndProgression { get; set; }
        public string HowToBecome { get; set; }
        public string SOC { get; set; }
        public string MinimumHours { get; set; }
        public string MaximumHours { get; set; }
    }
}
