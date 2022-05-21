namespace Portfolio.Client.Pages.Me;

public partial class Service
{
	[Inject]
	public HttpClient _httpClient { get; set; }

	private bool _loading { get; set; } = true;
	private List<ServiceInfo> serviceInfos { get; set; }

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		serviceInfos = await ServiceClient.GetFromJsonAsync<List<ServiceInfo>>("api/introduce/serviceinfos");

		if (serviceInfos == null || !serviceInfos.Any())
			Snackbar.Add("데이터가 없습니다.", MudBlazor.Severity.Info);
		else
		{
			foreach (var serviceInfo in serviceInfos)
			{
				switch (serviceInfo.Icon)
				{
					case "developermode": serviceInfo.Icon = Icons.Filled.DeveloperMode; break;
					case "design": serviceInfo.Icon = Icons.Filled.Devices; break;
					case "fill": serviceInfo.Icon = Icons.Filled.DevicesOther; break;
					default: serviceInfo.Icon = Icons.Filled.DeveloperMode; break;
				}
			}
		}

		_loading = false;
	}
}
