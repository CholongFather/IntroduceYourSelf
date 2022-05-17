namespace IntroduceMySelfAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UtilController : ControllerBase
{
	private readonly ILogger<UtilController> _logger;

	public UtilController(ILogger<UtilController> logger)
	{
		_logger = logger;
	}

	/// <summary>
	/// String to Color
	/// </summary>
	/// <returns></returns>
	[HttpGet("NameToColor")]
	public async ValueTask<string> NameToColor(string name)
	{
		var hash = 0;

		for (var i = 0; i < name.Length; i++)
		{
			hash = name[i] + ((hash << 5) - hash);
		}

		var color = "#";

		for (var i = 0; i < 3; i++)
		{
			var value = (hash >> (i * 8)) & 0xFF;
			color += value.ToString("X2");
		}

		return color;
	}
}

