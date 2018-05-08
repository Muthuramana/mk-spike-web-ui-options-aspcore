using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface ICareerPathService
    {
        Task<string> GetCareerPathAndProgressionAsync(string id);
    }
}