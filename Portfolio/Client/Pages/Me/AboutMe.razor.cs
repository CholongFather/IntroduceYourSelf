namespace Portfolio.Client.Pages.Me;

using System.Net.Http.Json;

public partial class AboutMe
{
	[Inject]
	public HttpClient _httpClient { get; set; }

	private bool _loading { get; set; } = true;

	private AboutMeInfo aboutMeInfo { get; set; }

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		aboutMeInfo = await _httpClient.GetFromJsonAsync<AboutMeInfo>("api/aboutme");

		if (aboutMeInfo == null || aboutMeInfo.Image == null)
			Snackbar.Add("데이터가 없습니다.", MudBlazor.Severity.Error);

		_loading = false;
	}
}