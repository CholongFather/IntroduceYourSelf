namespace Portfolio.Client.Pages;

public partial class Skills
{
	[Inject]
	public HttpClient _httpClient { get; set; }

	private bool _loading { get; set; } = true;

	protected override async Task OnInitializedAsync()
	{

	}
}