using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public interface IJobProfileSynopsisService
    {
        Task<JobProfileSynopsis> GetSynopsisAsync(string id);
    }
}