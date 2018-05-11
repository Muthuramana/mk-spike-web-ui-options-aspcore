using Careers.Freshlook.Helpers;
using Careers.Freshlook.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public class JobProfileSectionsService : IHowToBecomeService, IJobProfileSynopsisService, ICareerPathService, IWhatYouWillDoService, IWorkingPatternsService
    {
        private readonly ApiSettings configuration;
        private readonly IHostingEnvironment env;
        private Dictionary<string, JobProfileServiceModel> valuePairs = new Dictionary<string, JobProfileServiceModel>();

        public JobProfileSectionsService(IOptions<ApiSettings> configuration, IHostingEnvironment env)
        {
            this.configuration = configuration.Value;
            this.env = env;
        }

        public async Task<string> TryGetCareerPathAndProgressionAsync(string id)
        {
            await EnsureJobProfileSectionsAreCached(id);
            return valuePairs[id].CareerPathAndProgression;
        }

        public async Task<string> TryGetHowToBecomeAsync(string id)
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
                AlternativeTitles = valuePairs[id].AlternativeTitle,
                Overview = valuePairs[id].Overview
            };
        }

        public async Task<string> TryGetWhatYouWillDoAsync(string id)
        {
            await EnsureJobProfileSectionsAreCached(id);

            return valuePairs[id].WhatYouWillDo;
        }

        public async Task<WorkingHoursAndPatterns> GetWorkingHoursAndPatternsAsync(string id)
        {
            await EnsureJobProfileSectionsAreCached(id);
            return new WorkingHoursAndPatterns
            {
                TypicalWorkingHours = $"{valuePairs[id].MinimumHours ?? "38":##} to {valuePairs[id].MaximumHours ?? "40":##}",
                WorkingHoursDetail = $"Flexible",
                WorkingPattern = $"Mon-Fri"
            };
        }

        private async Task EnsureJobProfileSectionsAreCached(string id)
        {
            if (!valuePairs.ContainsKey(id))
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var result = await client.GetStringAsync($"{configuration.OthersEndpoint}/{id}");
                        valuePairs.Add(id, JsonConvert.DeserializeObject<JobProfileServiceModel>(result));
                    }
                }
                catch
                {
                    if (env.IsDevelopment())
                    {
                        throw;
                    }
                    else
                    {
                        valuePairs.Add(id, new JobProfileServiceModel
                        {
                            AlternativeTitle = "Service unavailable",
                            CareerPathAndProgression = "Service unavailable",
                            HowToBecome = "Service unavailable",
                            Id = "Service unavailable",
                            MaximumHours = "Service unavailable",
                            MinimumHours = "Service unavailable",
                            Overview = "Service unavailable",
                            Salary = "Service unavailable",
                            Skills = "Service unavailable",
                            Title = "Service unavailable",
                            UrlName = id,
                            WhatYouWillDo = "Service unavailable",
                            WorkingHoursPatternsAndEnvironment = "Service unavailable",
                        });
                    }
                }
            }
        }
    }
}