using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface ICurrentOppurtunitiesService
    {
        Task<string> TryGetCurrentOppurtunitiesAsync(string id);
    }
}