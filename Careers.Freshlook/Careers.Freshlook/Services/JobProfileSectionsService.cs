using Careers.Freshlook.Helpers;
using Careers.Freshlook.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public class JobProfileSectionsService : IHowToBecomeService, IJobProfileSynopsisService, ICareerPathService
    {
        private readonly ApiSettings configuration;
        private Dictionary<string, JobProfileServiceModel> valuePairs = new Dictionary<string, JobProfileServiceModel>();

        public JobProfileSectionsService(IOptions<ApiSettings> configuration)
        {
            this.configuration = configuration.Value;
        }

        public async Task<string> GetCareerPathAndProgressionAsync(string id)
        {
            await EnsureJobProfileSectionsAreCached(id);
            return valuePairs[id].CareerPathAndProgression;
        }

        public async Task<string> GetHowToBecomeAsync(string id)
        {
            await EnsureJobProfileSectionsAreCached(id);

            return valuePairs[id].HowToBecome;
        }

        public async Task<JobProfileSynopsis> GetSynopsisAsync(string id)
        {
            await EnsureJobProfileSectionsAreCached(id);

            return new JobProfileSynopsis
            {
                Title = valuePairs[id].Title,
                AlternativeTitles = new string[] { "Not Available" },
                Overview = valuePairs[id].Overview
            };
        }

        private async Task EnsureJobProfileSectionsAreCached(string id)
        {
            if (!valuePairs.ContainsKey(id))
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetStringAsync($"{configuration.OthersEndpoint}/{id}");
                    valuePairs.Add(id, JsonConvert.DeserializeObject<JobProfileServiceModel>(result));
                }
            }
        }
    }
}