using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IHowToBecomeService
    {
        Task<string> TryGetHowToBecomeAsync(string id);
    }
}