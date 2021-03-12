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

        [HttpGet]
        public async ValueTask<string> Get()
        {
            return await _redisCacheClient.GetDbFromConfiguration().GetAsync<string>("MyName");
        }
    }
}
