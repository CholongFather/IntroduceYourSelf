namespace Portfolio.Client.Pages.Me;

public partial class PortFolio
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