using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Models
{
    public class JobProfileViewModel
    {
        public IOrderedEnumerable<JobProfileSectionViewModel> Sections { get; set; }
    }
}
