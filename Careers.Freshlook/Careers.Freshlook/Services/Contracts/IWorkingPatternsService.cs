using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IWorkingPatternsService
    {
        Task<WorkingHoursAndPatterns> GetWorkingHoursAndPatternsAsync(string id);
    }
}