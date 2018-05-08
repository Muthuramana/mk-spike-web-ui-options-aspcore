using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface ISkillsService
    {
        Task<string> GetSkillsRequiredAsync(string id);
    }
}