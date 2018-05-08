using System.Collections.Generic;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IJobProfileService
    {
        Task<IEnumerable<JobProfileSection>> GetSectionsAsync(string id);
        Task<string> GetHeroBannerAsync(string id);
        Task<string> GetPageTitleAsync(string id);
    }
}