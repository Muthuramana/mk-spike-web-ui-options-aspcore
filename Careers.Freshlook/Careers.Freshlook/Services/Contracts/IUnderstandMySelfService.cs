using System.Threading.Tasks;
using Careers.Freshlook.Models;

namespace Careers.Freshlook.Services.Contracts
{
    public interface IUnderstandMySelfService
    {
        Task<string> GetStepDetails(int stepNumber, string sessionId);
        Task<string> GetResults(string sessionId);
        Task<string> SaveStepDetails(StepAnswer stepAnswer);

    }
}
