using System.Collections.Generic;

namespace Careers.Freshlook.Models
{
    public class StepAnswer
    {
        public int QuestionId { get; set; }

        public IEnumerable<string> SavedAnswers { get; set; }

        public string SessionId { get; set; }

        public string FrameworkItemType { get; set; }
    }
}