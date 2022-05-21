namespace Portfolio.Client.Pages.Me;

public partial class Career
{
	private bool _isLoading = true;
	private List<CareerInfo> _careerInfos;

	protected override async Task OnInitializedAsync()
	{
		await GetAsync();
	}

	private async Task GetAsync()
	{
		_careerInfos = await ServiceClient.GetFromJsonAsync<List<CareerInfo>>("api/introduce/career");

		if (_careerInfos == null || !_careerInfos.Any())
			Snackbar.Add("데이터가 없습니다.", MudBlazor.Severity.Error);

		_isLoading = false;
	}
}