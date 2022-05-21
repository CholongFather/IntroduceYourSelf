namespace Portfolio.Client.Pages.Monitoring;

public partial class DashBoard
{
	private bool _isLoading = true;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{

	}
}