using Portfolio.Client.Common;

namespace Portfolio.Client.Preferences;

public interface IPreferenceManager : IAppService
{
	Task SetPreference(IPreference preference);

	Task<IPreference> GetPreference();

	Task<bool> ChangeLanguageAsync(string languageCode);
}