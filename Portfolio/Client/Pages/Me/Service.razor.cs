namespace Portfolio.Client.Pages.Me;

public partial class Service
{
	private bool _isLoading = true;
	private List<ServiceInfo> _serviceInfos;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		_serviceInfos = await ServiceClient.GetFromJsonAsync<List<ServiceInfo>>("api/introduce/serviceinfos");

		if (_serviceInfos == null || !_serviceInfos.Any())
			Snackbar.Add("데이터가 없습니다.", MudBlazor.Severity.Info);
		else
		{
			foreach (ServiceInfo? serviceInfo in _serviceInfos)
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

		_isLoading = false;
	}
}
