namespace Portfolio.Client.Components.ThemeManager;

public partial class TableCustomizationPanel
{
	[Parameter]
	public bool IsDense { get; set; }
	[Parameter]
	public bool IsStriped { get; set; }
	[Parameter]
	public bool HasBorder { get; set; }
	[Parameter]
	public bool IsHoverable { get; set; }

	protected override async Task OnInitializedAsync()
	{
		if (await ClientPreferences.GetPreference() is ClientPreference clientPreference)
		{
		}
	}

	[Parameter]
	public EventCallback<bool> OnDenseSwitchToggled { get; set; }

	[Parameter]
	public EventCallback<bool> OnStripedSwitchToggled { get; set; }

	[Parameter]
	public EventCallback<bool> OnBorderdedSwitchToggled { get; set; }

	[Parameter]
	public EventCallback<bool> OnHoverableSwitchToggled { get; set; }

	private async Task ToggleDenseSwitch()
	{
	}

	private async Task ToggleStripedSwitch()
	{
	}

	private async Task ToggleBorderedSwitch()
	{
	}

	private async Task ToggleHoverableSwitch()
	{
	}
}