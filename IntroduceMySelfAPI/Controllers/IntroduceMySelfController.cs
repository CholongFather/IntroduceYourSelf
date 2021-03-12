using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroduceMySelf.DTO;

namespace IntroduceMySelfAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntroduceMySelfController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<IntroduceMySelfController> _logger;

        public IntroduceMySelfController(ILogger<IntroduceMySelfController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async IEnumerable<IntroduceMySelfModel> Get()
        {

            return null;
        }
    }
}
