using MudBlazor;

namespace Portfolio.Client.Pages.Component;

public partial class Alert
{
	[Inject]
	public HttpClient _httpClient { get; set; }

	private bool _loading { get; set; } = true;

	private int _elevation { get; set; } = 1;

	private bool _dense { get; set; } = false;

	private HorizontalAlignment _horizontalAlignment { get; set; } = HorizontalAlignment.Left;

	protected override async Task OnInitializedAsync()
	{
	}
}