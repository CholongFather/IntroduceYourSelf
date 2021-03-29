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
    public class MonitoringController : ControllerBase
    {
        private readonly ILogger<IntroduceMySelfController> _logger;
        private readonly IRedisCacheClient _redisCacheClient;

        public MonitoringController(ILogger<IntroduceMySelfController> logger, IRedisCacheClient redisCacheClient)
        {
            _logger = logger;
            _redisCacheClient = redisCacheClient;
        }

		/// <summary>
		/// CPU Monitoring Data (Last 30 Days)
		/// </summary>
		/// <param name="serverName">서버 명</param>
		/// <param name="dateTime">일자</param>
		/// <returns>일자별 데이터</returns>
		[HttpGet("Monitoring/Cpu")]
		public async ValueTask<MonitoringCpuDateModel> MonitoringCpu(string serverName, DateTime dateTime)
		{
			return await _redisCacheClient.GetDbFromConfiguration().GetAsync<MonitoringCpuDateModel>($"{serverName}_{dateTime.ToString("yyyyMMdd")}_CPU");
		}
	}
}
