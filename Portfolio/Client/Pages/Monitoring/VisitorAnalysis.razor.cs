namespace Portfolio.Client.Pages.Monitoring;

public partial class VisitorAnalysis
{
	private bool _loading { get; set; } = true;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{

	}
}