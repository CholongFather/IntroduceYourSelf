using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroduceMySelf.DTO;
using Newtonsoft.Json;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Newtonsoft;
using StackExchange.Redis.Extensions;

namespace IntroduceMySelfAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntroduceMySelfController : ControllerBase
    {
        private readonly ILogger<IntroduceMySelfController> _logger;
        private readonly IRedisCacheClient _redisCacheClient;

        public IntroduceMySelfController(ILogger<IntroduceMySelfController> logger, IRedisCacheClient redisCacheClient)
        {
            _logger = logger;
            _redisCacheClient = redisCacheClient;
        }

        /// <summary>
        /// 이름 데이터
        /// </summary>
        /// <returns></returns>
        [HttpGet("MyName")]
        public async ValueTask<string> GetName()
        {
            return await _redisCacheClient.GetDbFromConfiguration().GetAsync<string>("MyName");
        }

        /// <summary>
        /// 소개데이터
        /// </summary>
        /// <returns></returns>
        [HttpGet("Introduce")]
        public async ValueTask<Introduce> GetIntroduce()
        {
            return await _redisCacheClient.GetDbFromConfiguration().GetAsync<Introduce>("SangWan");
        }

        /// <summary>
        /// 기본 데이터 셋
        /// </summary>
        /// <returns></returns>
        [HttpPost("SetSangWan")]
        public async ValueTask PostIntroduce()
        {
            var sangWan = new Introduce();
            sangWan.Author = new Author()
            {
                Name = "Park Sang Wan",
                Age = 99,
                CareerYear = (DateTime.Now - new DateTime(1990,1,1)).Days / 365,
            };
            sangWan.Carrer = new List<ProfessionalExperience>();


            ///Json 파일 읽어서 하는걸로 바꿀것.
            var professionalExperience = new ProfessionalExperience()
            {
                ProjectName = "참좋은여행",
                Company = "참좋은여행",
                ImageLink = "#",
                SkillInventory = new List<string> { "Jquery", "ASP.NET", "반응형" },
            };

            ProfessionalExperience professionalExperience2 = new ProfessionalExperience()
            {
                ProjectName = "참좋은여행 불꽃폭발",
                Company = "참망한여행",
                ImageLink = "#",
                SkillInventory = new List<string> { "Jquery 1.12.4", "반응형" },
            };

            sangWan.Carrer.Add(professionalExperience);
            sangWan.Carrer.Add(professionalExperience2);

            await _redisCacheClient.GetDbFromConfiguration().AddAsync<Introduce>("SangWan", sangWan);
        }
    }
}
