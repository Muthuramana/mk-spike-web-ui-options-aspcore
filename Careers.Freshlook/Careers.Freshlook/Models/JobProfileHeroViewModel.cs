using System.Collections.Generic;

namespace Careers.Freshlook.Models
{
    public class JobProfileHeroViewModel
    {
        public string Title { get; set; }
        public IEnumerable<string> AlternativeTitles { get; set; }
        public string Overview { get; set; }
        public int SalaryStarter { get; set; }
        public int SalaryExperienced { get; set; }
        public string TypicalHours { get; set; }

    }
}