using IntroduceMySelf.DTO;

using Microsoft.AspNetCore.Mvc;

using Portfolio.Shared;

namespace Portfolio.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IntroduceController : ControllerBase
	{
		private readonly ILogger<IntroduceController> _logger;

		public IntroduceController(ILogger<IntroduceController> logger)
		{
			_logger = logger;
		}

		[HttpGet("serviceinfos")]
		public async ValueTask<List<ServiceInfo>> Get()
		{
			HttpClient client = new HttpClient();
			try
			{
				var serviceInfos = await client.GetFromJsonAsync<List<ServiceInfo>>("http://localhost:8080/IntroduceMySelf/Introduce");

				if (serviceInfos == null)
					return new();

				return serviceInfos;
			}
			catch (Exception ex)
			{
				return new();
			}
		}
	}
}