using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Careers.Freshlook.Helpers;
using Careers.Freshlook.Models;
using Careers.Freshlook.Services.Contracts;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Careers.Freshlook.Services
{
    public class UnderstandMySelfService : IUnderstandMySelfService
    {
        private readonly ApiSettings configuration;

        public UnderstandMySelfService(IOptions<ApiSettings> configuration)
        {
            this.configuration = configuration.Value;
        }
        public async Task<string> GetStepDetails(int stepNumber, string sessionId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{configuration.UnderstandMyselfEndpoint}/{stepNumber}/{sessionId}");
                    var result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Dictionary<string, string>>(result).FirstOrDefault().Value;
                    }
                    else
                    {
                        return $"{response} - Understand myself service is unavailable at the moment. Try again later.";
                    }
                }
                catch (Exception ex)
                {
                    return $"{ex} - Understand myself is unavailable at the moment. Try again later.";
                    //throw new Exception($"Failed to get skills from {configuration.SkillsEndpoint}/{id}", ex);
                }
            }
        }

        public async Task<string> GetResults(string sessionId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{configuration.UnderstandMyselfEndpoint}/results/{sessionId}");
                    var result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Dictionary<string, string>>(result).FirstOrDefault().Value;
                    }
                    else
                    {
                        return $"{response} - Understand myself service is unavailable at the moment. Try again later.";
                    }
                }
                catch (Exception ex)
                {
                    return $"{ex} - Understand myself is unavailable at the moment. Try again later.";
                    //throw new Exception($"Failed to get skills from {configuration.SkillsEndpoint}/{id}", ex);
                }
            }
        }

        public async Task<string> SaveStepDetails(StepAnswer stepAnswer)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(stepAnswer), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{configuration.UnderstandMyselfEndpoint}/savestepanswer", stringContent);
                    var result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Dictionary<string, string>>(result).FirstOrDefault().Value;
                    }
                    else
                    {
                        return $"{response} - Understand myself service is unavailable at the moment. Try again later.";
                    }
                }
                catch (Exception ex)
                {
                    return $"{ex} - Understand myself is unavailable at the moment. Try again later.";
                    //throw new Exception($"Failed to get skills from {configuration.SkillsEndpoint}/{id}", ex);
                }
            }
        }
    }
}
