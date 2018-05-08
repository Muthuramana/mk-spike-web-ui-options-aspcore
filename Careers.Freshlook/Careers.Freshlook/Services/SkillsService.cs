using Careers.Freshlook.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Careers.Freshlook.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ApiSettings configuration;

        public SkillsService(IOptions<ApiSettings> configuration)
        {
            this.configuration = configuration.Value;
        }
        public async Task<string> GetSkillsRequiredAsync(string id)
        {
            //using (var client = new HttpClient())
            //{
            //    var result = await client.GetStringAsync($"{configuration["endpoint_skillssection"]}/{id}");

            //}

            return await Task.FromResult("skills");
        }
    }
}
