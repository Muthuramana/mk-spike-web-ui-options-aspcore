using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface ISalaryService
    {
        Task<int> GetStarterSalaryAsync(string id);
        Task<int> GetExperiencedSalaryAsync(string id);
    }
}