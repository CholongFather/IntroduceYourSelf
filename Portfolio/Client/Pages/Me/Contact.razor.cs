namespace Portfolio.Client.Pages.Me;

public partial class Contact
{
	private bool _isLoading = true;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		_isLoading = false;
	}
}