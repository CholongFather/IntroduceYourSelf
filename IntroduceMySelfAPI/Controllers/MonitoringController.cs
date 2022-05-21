using System.Globalization;

namespace IntroduceMySelfAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MonitoringController : ControllerBase
{
	private readonly ILogger<MonitoringController> _logger;
	private readonly IRedisCacheClient _redisCacheClient;
	private CultureInfo _provider = CultureInfo.InvariantCulture;
	public MonitoringController(ILogger<MonitoringController> logger, IRedisCacheClient redisCacheClient)
	{
		_logger = logger;
		_redisCacheClient = redisCacheClient;
	}

	[HttpGet("serverList")]
	public async ValueTask<List<string>> GetMonitoringServerNames()
	{
		var monitoringServerList = await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<string>>("Monitoring:ServerName");

		return monitoringServerList;
	}

	[HttpPost("cpu")]
	public async ValueTask<List<MonitoringCpuModel>> MonitoringCpu(MonitoringRequest request)
	{
		var cpuMonitoringKeys = await _redisCacheClient.GetDbFromConfiguration().SearchKeysAsync($"{request.ServerName}:*:CPU");
		var cpuMonitoringInfo = new List<MonitoringCpuModel>();

		foreach (var cpuMonitoringKey in cpuMonitoringKeys)
		{
			var cpuMonitoringDate = DateTime.ParseExact(cpuMonitoringKey.Split(':')[1], "yyyyMMdd", _provider);

			if (cpuMonitoringDate < request.StartAt || cpuMonitoringDate > request.EndAt)
				continue;

			cpuMonitoringInfo.AddRange(await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<MonitoringCpuModel>>(cpuMonitoringKey));
		}

		return cpuMonitoringInfo.OrderBy(c => c.Time).ToList();
	}

	[HttpPost("memory")]
	public async ValueTask<List<MonitoringMemoryModel>> MonitoringMemory(MonitoringRequest request)
	{
		var memoryMonitoringDateKeys = await _redisCacheClient.GetDbFromConfiguration().SearchKeysAsync($"{request.ServerName}:*:MEMORY");

		var memoryMonitoringInfos = new List<MonitoringMemoryModel>();

		foreach (var memoryMonitoringDateKey in memoryMonitoringDateKeys)
		{
			var memoryMonitoringDate = DateTime.ParseExact(memoryMonitoringDateKey.Split(':')[1], "yyyyMMdd", _provider);

			if (memoryMonitoringDate < request.StartAt || memoryMonitoringDate > request.EndAt)
				continue;

			memoryMonitoringInfos.AddRange(await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<MonitoringMemoryModel>>(memoryMonitoringDateKey));
		}

		return memoryMonitoringInfos.OrderBy(c => c.Time).ToList();
	}

	[HttpPost("disk")]
	public async ValueTask<List<MonitoringDiskModel>> MonitoringDisk(MonitoringRequest request)
	{
		var diskMonitoringKeys = await _redisCacheClient.GetDbFromConfiguration().SearchKeysAsync($"{request.ServerName}:*:DISK");

		var diskMonitoringInfos = new List<MonitoringDiskModel>();

		foreach (var diskMonitoringKey in diskMonitoringKeys)
		{
			var diskMonitoringDate = DateTime.ParseExact(diskMonitoringKey.Split(':')[1], "yyyyMMdd", _provider);

			if (diskMonitoringDate < request.StartAt || diskMonitoringDate > request.EndAt)
				continue;

			diskMonitoringInfos.AddRange(await _redisCacheClient.GetDbFromConfiguration().GetAsync<List<MonitoringDiskModel>>(diskMonitoringKey));
		}

		return diskMonitoringInfos.OrderBy(c => c.Time).ToList();
	}

	[HttpPost("visit")]
	public async ValueTask Visitor()
	{
		var ip = GetHeaderInfos.GetClientIp(Request);

		var userAgent = GetHeaderInfos.GetUserAgent(Request);
	}
}
