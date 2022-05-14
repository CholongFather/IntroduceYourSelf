﻿using Portfolio.Client.Theme;

namespace Portfolio.Client.Components.ThemeManager;

public partial class ThemeDrawer
{
	[Parameter]
	public bool ThemeDrawerOpen { get; set; }

	[Parameter]
	public EventCallback<bool> ThemeDrawerOpenChanged { get; set; }

	[EditorRequired]
	[Parameter]
	public ClientPreference ThemePreference { get; set; } = default!;

	[EditorRequired]
	[Parameter]
	public EventCallback<ClientPreference> ThemePreferenceChanged { get; set; }

	private readonly List<string> _colors = CustomColors.ThemeColors;

	private async Task UpdateThemePrimaryColor(string color)
	{
		if (ThemePreference is not null)
		{
			ThemePreference.PrimaryColor = color;
			await ThemePreferenceChanged.InvokeAsync(ThemePreference);
		}
	}

	private async Task UpdateThemeSecondaryColor(string color)
	{
		if (ThemePreference is not null)
		{
			ThemePreference.SecondaryColor = color;
			await ThemePreferenceChanged.InvokeAsync(ThemePreference);
		}
	}

	private async Task UpdateBorderRadius(double radius)
	{
		if (ThemePreference is not null)
		{
			ThemePreference.BorderRadius = radius;
			await ThemePreferenceChanged.InvokeAsync(ThemePreference);
		}
	}

	private async Task ToggleDarkLightMode(bool isDarkMode)
	{
		if (ThemePreference is not null)
		{
			ThemePreference.IsDarkMode = isDarkMode;
			await ThemePreferenceChanged.InvokeAsync(ThemePreference);
		}
	}

	private async Task ToggleEntityTableDense(bool isDense)
	{
	}

	private async Task ToggleEntityTableStriped(bool isStriped)
	{
	}

	private async Task ToggleEntityTableBorder(bool hasBorder)
	{

	}

	private async Task ToggleEntityTableHoverable(bool isHoverable)
	{
	}
}