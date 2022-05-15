namespace Portfolio.Client.Pages.Me;

using System.Net.Http.Json;

public partial class PortFolio
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
	}
}