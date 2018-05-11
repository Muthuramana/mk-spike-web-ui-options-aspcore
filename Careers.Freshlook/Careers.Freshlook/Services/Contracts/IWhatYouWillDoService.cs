using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IWhatYouWillDoService
    {
        Task<string> TryGetWhatYouWillDoAsync(string id);
    }
}