namespace Portfolio.Client.Shared;

public partial class MainLayout
{
	[Parameter]
	public RenderFragment ChildContent { get; set; } = default!;

	[Parameter]
	public EventCallback OnDarkModeToggle { get; set; }

	[Parameter]
	public EventCallback<bool> OnRightToLeftToggle { get; set; }

	private bool _drawerOpen;
	private bool _rightToLeft;

	protected override async Task OnInitializedAsync()
	{
	}

	private async Task RightToLeftToggle()
	{
		var isRtl = await ClientPreferences.ToggleLayoutDirectionAsync();

		_rightToLeft = isRtl;

		await OnRightToLeftToggle.InvokeAsync(isRtl);
	}

	public async Task ToggleDarkMode()
	{
		await OnDarkModeToggle.InvokeAsync();
	}

	private async Task DrawerToggle()
	{
		_drawerOpen = await ClientPreferences.ToggleDrawerAsync();
	}

	private void Logout()
	{
		var parameters = new DialogParameters
		{
		};

		var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };
	}

	private void Profile()
	{
		Navigation.NavigateTo("/account");
	}
}