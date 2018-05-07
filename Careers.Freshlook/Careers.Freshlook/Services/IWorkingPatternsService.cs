using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IWorkingPatternsService
    {
        Task<WorkingHoursAndPatterns> GetWorkingHoursAndPatterns(string id);
    }
}