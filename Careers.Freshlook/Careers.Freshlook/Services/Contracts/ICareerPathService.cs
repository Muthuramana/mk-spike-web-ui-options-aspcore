using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface ICareerPathService
    {
        Task<string> TryGetCareerPathAndProgressionAsync(string id);
    }
}