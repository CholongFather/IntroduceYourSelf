namespace IntroduceMySelfAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MonitoringController : ControllerBase
{
	private readonly ILogger<MonitoringController> _logger;
	private readonly IRedisCacheClient _redisCacheClient;

	public MonitoringController(ILogger<MonitoringController> logger, IRedisCacheClient redisCacheClient)
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
	[HttpGet("Cpu")]
	public async ValueTask<MonitoringCpuDateModel> MonitoringCpu(string serverName, DateTime dateTime)
	{
		return await _redisCacheClient.GetDbFromConfiguration().GetAsync<MonitoringCpuDateModel>($"{serverName}_{dateTime.ToString("yyyyMMdd")}_CPU");
	}
}
