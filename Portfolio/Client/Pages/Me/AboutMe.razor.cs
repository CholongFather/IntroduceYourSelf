namespace Portfolio.Client.Pages.Me;

public partial class AboutMe
{
	private bool _isLoading = true;
	private AboutMeInfo _aboutMeInfo;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		_aboutMeInfo = await ServiceClient.GetFromJsonAsync<AboutMeInfo>("api/aboutme");

		if (_aboutMeInfo == null || _aboutMeInfo.Image == null)
			Snackbar.Add("데이터가 없습니다.", MudBlazor.Severity.Error);

		_isLoading = false;
	}
}