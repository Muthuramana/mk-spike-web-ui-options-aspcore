using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careers.Freshlook.Models
{
    public class SearchViewModel
    {
        public string Id { get; set; }
        public string SearchTerm { get; set; }

        public string LabelText { get; set; }

        public int AutoCompleteMinimumCharacters { get; set; }

        public int MaximumNumberOfDisplayedSuggestions { get; set; }

        public bool UseFuzzyAutoCompleteMatching { get; set; }


    }
}
