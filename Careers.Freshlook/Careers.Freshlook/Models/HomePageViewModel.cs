using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Models
{
    public class HomePageViewModel : SearchViewModel
    {
        public IDictionary<string, string> JobProfiles { get; set; }
    }
}
