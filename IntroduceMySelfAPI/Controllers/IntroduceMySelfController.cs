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
        /// 소개 데이터 Get
        /// </summary>
        /// <returns></returns>
        [HttpGet("Introduce")]
        public async ValueTask<Introduce> GetIntroduce()
        {
            return await _redisCacheClient.GetDbFromConfiguration().GetAsync<Introduce>("sangwan");
        }

        /// <summary>
        /// 기본 데이터 세팅
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

            await _redisCacheClient.GetDbFromConfiguration().AddAsync<Introduce>("sangwan", sangWan);
        }

        /// <summary>
        /// 기본 소개 내용을 추가합니다.
        /// </summary>
        /// <param name="introduce">소개 내용</param>
        /// <returns></returns>
        [HttpPost("SetCustom")]
        public async ValueTask PostIntroduceCustom(Introduce introduce)
        {
            await _redisCacheClient.GetDbFromConfiguration().AddAsync<Introduce>(introduce.Author.Name.ToLower(), introduce);
        }

        /// <summary>
        /// career를 추가합니다.
        /// </summary>
        /// <param name="name">career 추가할 사람 이름</param>
        /// <param name="career">career 내용</param>
        /// <returns>200 ok</returns>
        [HttpPost("SetCareer")]
        public async ValueTask PostIntroduceCustom(string name, ProfessionalExperience career)
        {
            var introduceItem = await _redisCacheClient.GetDbFromConfiguration().GetAsync<Introduce>(name);

            if (introduceItem.Carrer != null)
                introduceItem.Carrer.Add(career);
            else
                introduceItem.Carrer = new List<ProfessionalExperience>() { career };

            await _redisCacheClient.GetDbFromConfiguration().ReplaceAsync<Introduce>(introduceItem.Author.Name.ToLower(), introduceItem);
        }
    }
}
