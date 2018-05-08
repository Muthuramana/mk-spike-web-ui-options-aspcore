using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IWhatYouWillDoService
    {
        Task<string> GetWhatYouWillDoAsync(string id);
    }
}