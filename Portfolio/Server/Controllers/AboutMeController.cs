using IntroduceMySelf.DTO;

using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AboutMeController : ControllerBase
{
	private readonly ILogger<AboutMeController> _logger;

	public AboutMeController(ILogger<AboutMeController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public async ValueTask<AboutMeInfo> Get()
	{
		var client = new HttpClient();

		try
		{
			var aboutMeInfo = await client.GetFromJsonAsync<AboutMeInfo>("http://localhost:8080/IntroduceMySelf/aboutme?name=knh");

			if (aboutMeInfo == null)
				return new();

			return aboutMeInfo;
		}
		catch (Exception ex)
		{
			return new();
		}
	}
}
