namespace Portfolio.Client.Pages.Me;

public partial class Contact
{
	private bool _loading { get; set; } = true;
	private List<CareerInfo> careerInfos { get; set; }

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		careerInfos = await ServiceClient.GetFromJsonAsync<List<CareerInfo>>("api/introduce/career");

		if (careerInfos == null || !careerInfos.Any())
			Snackbar.Add("데이터가 없습니다.", MudBlazor.Severity.Error);

		_loading = false;
	}
}