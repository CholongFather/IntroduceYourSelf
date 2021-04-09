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
		/// 소개 데이터 조회
		/// </summary>
		/// <param name="name">조회 이름</param>
		/// <returns></returns>
		[HttpGet("Introduce")]
		public async ValueTask<Introduce> GetIntroduce(string name)
		{
			return await _redisCacheClient.GetDbFromConfiguration().GetAsync<Introduce>(name.ToLower());
		}

		/// <summary>
		/// 소개 데이터 추가
		/// </summary>
		/// <param name="introduce">소개 데이터 객체</param>
		/// <returns></returns>
		[HttpPost("Introduce")]
		public async ValueTask AddIntroduce(Introduce introduce)
		{
			if (introduce?.Author == null)
				return;

			await _redisCacheClient.GetDbFromConfiguration().AddAsync<Introduce>(introduce.Author.Name.ToLower(), introduce);
		}

		/// <summary>
		/// career를 추가합니다.
		/// </summary>
		/// <param name="name">career 추가할 사람 이름</param>
		/// <param name="career">career 내용</param>
		/// <returns>200 ok</returns>
		[HttpPost("Career")]
		public async ValueTask AddCareer(string name, ProfessionalExperience career)
		{
			var introduceItem = await _redisCacheClient.GetDbFromConfiguration().GetAsync<Introduce>(name.ToLower());

			if (introduceItem.Career != null)
			{
				var introduceCareer = introduceItem.Career.FirstOrDefault(a => a.Index == career.Index);

				if (introduceCareer != null)
					introduceItem.Career.Remove(introduceCareer);

				introduceItem.Career.Add(career);
			}
			else
				introduceItem.Career = new List<ProfessionalExperience>() { career };

			await _redisCacheClient.GetDbFromConfiguration().ReplaceAsync<Introduce>(introduceItem.Author.Name.ToLower(), introduceItem);
		}

		/// <summary>
		/// 소개 데이터 제거
		/// </summary>
		/// <param name="name">이름</param>
		/// <returns></returns>
		[HttpDelete("Introduce/{name}")]
		public async ValueTask RemoveIntroduce(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return;

			await _redisCacheClient.GetDbFromConfiguration().RemoveAsync(name.ToLower());
		}
	}
}
