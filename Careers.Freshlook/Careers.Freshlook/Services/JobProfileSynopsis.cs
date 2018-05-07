using System.Collections.Generic;

namespace Careers.Freshlook.Services
{
    public class JobProfileSynopsis
    {
        public string Title { get; set; }
        public IEnumerable<string> AlternativeTitles { get; set; }
        public string Overview { get; set; }

    }
}