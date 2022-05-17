namespace Portfolio.Client.Pages.Monitoring;

public partial class VisitorAnalysis
{
	[Inject]
	public HttpClient _httpClient { get; set; }

	private bool _loading { get; set; } = true;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{

	}
}