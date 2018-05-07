using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Models
{
    public class JobProfileViewModel
    {
        public string HeroBannerContent { get; set; }
        public IOrderedEnumerable<JobProfileSectionViewModel> Sections { get; set; }
    }
}
