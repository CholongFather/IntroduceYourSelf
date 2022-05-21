using IntroduceMySelf.DTO;

using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonitoringController : ControllerBase
{
	private readonly ILogger<AboutMeController> _logger;

	public MonitoringController(ILogger<AboutMeController> logger)
	{
		_logger = logger;
	}

	[HttpGet("serverNames")]
	public async ValueTask<List<string>> GetServerNames()
	{
		var client = new HttpClient();

		try
		{
			var serverNames = await client.GetFromJsonAsync<List<string>>("http://localhost:8080/Monitoring/serverList");

			if (serverNames == null)
				return new();

			return serverNames;
		}
		catch (Exception ex)
		{
			return new();
		}
	}

	[HttpPost("cpu")]
	public async ValueTask<List<MonitoringCpuModel>> MonitoringCpu(MonitoringRequest request)
	{
		var client = new HttpClient();

		try
		{
			var response = await client.PostAsJsonAsync("http://localhost:8080/monitoring/cpu", request);

			response.EnsureSuccessStatusCode();

			var cpuMonitoringInfos = await response.Content.ReadFromJsonAsync<List<MonitoringCpuModel>>();

			return cpuMonitoringInfos;
		}
		catch (Exception ex)
		{
			return new();
		}
	}

	[HttpPost("memory")]
	public async ValueTask<List<MonitoringMemoryModel>> MonitoringMemory(MonitoringRequest request)
	{
		var client = new HttpClient();

		try
		{
			var response = await client.PostAsJsonAsync("http://localhost:8080/monitoring/memory", request);

			response.EnsureSuccessStatusCode();

			var memoryMonitoringInfos = await response.Content.ReadFromJsonAsync<List<MonitoringMemoryModel>>();

			return memoryMonitoringInfos;
		}
		catch (Exception ex)
		{
			return new();
		}
	}

	[HttpPost("disk")]
	public async ValueTask<List<MonitoringDiskModel>> MonitoringDisk(MonitoringRequest request)
	{
		var client = new HttpClient();

		try
		{
			var response = await client.PostAsJsonAsync("http://localhost:8080/monitoring/disk", request);

			response.EnsureSuccessStatusCode();

			var diskMonitoringInfos = await response.Content.ReadFromJsonAsync<List<MonitoringDiskModel>>();

			return diskMonitoringInfos;
		}
		catch (Exception ex)
		{
			return new();
		}
	}
}
