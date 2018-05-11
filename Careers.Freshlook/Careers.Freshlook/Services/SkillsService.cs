using Careers.Freshlook.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Careers.Freshlook.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ApiSettings configuration;

        public SkillsService(IOptions<ApiSettings> configuration)
        {
            this.configuration = configuration.Value;
        }
        public async Task<string> TryGetSkillsRequiredAsync(string id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{configuration.SkillsEndpoint}/{id}");
                    var result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var poco = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                        return poco["Skills"];
                    }
                    else
                    {
                        return "Skill service is unavailable at the moment. Try again later.";
                    }
                }
                catch (Exception ex)
                {
                    return "Skill service is unavailable at the moment. Try again later.";
                    //throw new Exception($"Failed to get skills from {configuration.SkillsEndpoint}/{id}", ex);
                }
            }
        }
    }
}
