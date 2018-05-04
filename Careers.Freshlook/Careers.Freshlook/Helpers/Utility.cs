using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Careers.Freshlook.Helpers
{
    public static class Utility
    {
        public static string GenerateId(string name) => Regex.Replace(name, "[\\W \\s]", string.Empty);
    }
}
