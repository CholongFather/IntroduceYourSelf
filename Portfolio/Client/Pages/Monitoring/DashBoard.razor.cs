using Newtonsoft.Json;

namespace Portfolio.Client.Pages.Monitoring;

public partial class DashBoard
{
	private bool _isLoading = false;
	private List<string> _serverNames;
	private string _serverName;
	private DateTime? _startAt = DateTime.Today.AddDays(-7);
	private DateTime? _endAt = DateTime.Today;
	private List<MonitoringCpuModel> _monitoringCpuList;
	private List<MonitoringMemoryModel> _monitoringMemoryList;
	private List<MonitoringDiskModel> _monitoringDiskList;

	private List<ChartSeries> _cpuSeries;
	private List<ChartSeries> _memorySeries;
	private Dictionary<string, List<ChartSeries>> _diskSeriesList;

	private string[] _cpuXAxisLabels;
	private string[] _memoryXAxisLabels;
	private string[] _diskXAxisLabels;

	private ChartOptions options = new ChartOptions()
	{
		LineStrokeWidth = 1,
		YAxisTicks = 2,
		YAxisLines = true,
	};

	protected override async Task OnInitializedAsync()
	{
		_isLoading = true;
		await InvokeAsync(StateHasChanged);

		await GetMonitoringServerName();
		await GetCpuMonitoringAsync();
		await GetMemoryMonitoringAsync();
		await GetDiskMonitoringAsync();

		_isLoading = false;
		await InvokeAsync(StateHasChanged);
	}

	private async Task ReloadData()
	{
		_isLoading = true;
		await InvokeAsync(StateHasChanged);

		await GetCpuMonitoringAsync();
		await GetMemoryMonitoringAsync();
		await GetDiskMonitoringAsync();

		_isLoading = false;
		await InvokeAsync(StateHasChanged);
	}

	private async Task GetMonitoringServerName()
	{
		_serverNames = await ServiceClient.GetFromJsonAsync<List<string>>("api/monitoring/serverNames");

		if (!_serverNames.Any())
			Snackbar.Add("데이터가 없습니다.", Severity.Error);

		_serverName = _serverNames.FirstOrDefault();
	}

	private async Task GetCpuMonitoringAsync()
	{
		var request = new MonitoringRequest
		{
			ServerName = _serverName,
			StartAt = _startAt.Value,
			EndAt = _endAt.Value,
		};

		var response = await ServiceClient.PostAsJsonAsync("api/monitoring/cpu", request);

		if (response.IsSuccessStatusCode)
		{
			var cpuResponseContent = await response.Content.ReadAsStringAsync();

			Console.WriteLine(cpuResponseContent);

			_monitoringCpuList = JsonConvert.DeserializeObject<List<MonitoringCpuModel>>(cpuResponseContent);

			_cpuSeries = new()
			{
				new() { Name = "Cpu", Data = _monitoringCpuList.Select(c => Convert.ToDouble(c.ProcessTime)).ToArray() },
			};

			_cpuXAxisLabels = _monitoringCpuList.Select(c => Convert.ToDateTime(c.Time).ToString("MM-dd HH:mm")).ToArray();
		}
	}

	private async Task GetMemoryMonitoringAsync()
	{
		var request = new MonitoringRequest
		{
			ServerName = _serverName,
			StartAt = _startAt.Value,
			EndAt = _endAt.Value,
		};

		var response = await ServiceClient.PostAsJsonAsync("api/monitoring/memory", request);

		if (response.IsSuccessStatusCode)
		{
			var memoryResponseContent = await response.Content.ReadAsStringAsync();

			Console.WriteLine(memoryResponseContent);

			_monitoringMemoryList = JsonConvert.DeserializeObject<List<MonitoringMemoryModel>>(memoryResponseContent);

			_memorySeries = new()
			{
				new() { Name = "Memory AvailalbleBytes", Data = _monitoringMemoryList.Select(c => c.AvailableBytes).ToArray() },
				new() { Name = "Memory UsageBytes", Data = _monitoringMemoryList.Select(c => c.UsageBytes).ToArray() },
			};

			_memoryXAxisLabels = _monitoringMemoryList.Select(c => Convert.ToDateTime(c.Time).ToString("MM-dd HH:mm")).ToArray();
		}
	}

	private async Task GetDiskMonitoringAsync()
	{
		var request = new MonitoringRequest
		{
			ServerName = _serverName,
			StartAt = _startAt.Value,
			EndAt = _endAt.Value,
		};

		var response = await ServiceClient.PostAsJsonAsync("api/monitoring/disk", request);

		if (response.IsSuccessStatusCode)
		{
			var diskResponseContent = await response.Content.ReadAsStringAsync();

			Console.WriteLine(diskResponseContent);

			_monitoringDiskList = JsonConvert.DeserializeObject<List<MonitoringDiskModel>>(diskResponseContent);

			_diskSeriesList = new();

			var drives = _monitoringDiskList.Select(d => d.Drive).Distinct();

			foreach (var drive in drives)
			{
				var diskSeries = new List<ChartSeries>();

				var diskTotalFreeChart = new ChartSeries { Name = $"Disk {drive} TotalFree", Data = _monitoringDiskList.Where(d => d.Drive == drive).Select(c => c.TotalFreeSpace).ToArray() };
				var diskTotalChart = new ChartSeries { Name = $"Disk {drive} TotalSize", Data = _monitoringDiskList.Where(d => d.Drive == drive).Select(c => c.TotalSize).ToArray() };

				diskSeries.Add(diskTotalFreeChart);
				diskSeries.Add(diskTotalChart);

				_diskSeriesList.Add($"Disk {drive}", diskSeries);
			}

			_diskXAxisLabels = _monitoringDiskList.Where(d => d.Drive == "C").Select(c => Convert.ToDateTime(c.Time).ToString("MM-dd HH:mm")).ToArray();
		}
	}
}