using MudBlazor;

namespace Portfolio.Client.Preferences;

public interface IClientPreferenceManager : IPreferenceManager
{
	Task<MudTheme> GetCurrentThemeAsync();

	Task<bool> ToggleDarkModeAsync();

	Task<bool> ToggleDrawerAsync();

	Task<bool> ToggleLayoutDirectionAsync();
}