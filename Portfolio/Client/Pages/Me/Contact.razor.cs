namespace Portfolio.Client.Pages.Me;

public partial class Contact
{
	private bool _isLoading = true;
	private string _name;
	private string _email;
	private string _contact;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		_isLoading = false;
	}
}