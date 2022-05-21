namespace Portfolio.Client.Pages.Component.Buttons;

public partial class ToggleIconButton
{
	private bool _isAlarmOn;
	private int _switchedOnCount;
	private const int _maxCount = 5;

	protected override async Task OnInitializedAsync()
	{
	}

	private async Task OnToggledChanged(bool toggled)
	{
		_isAlarmOn = toggled;

		if (_isAlarmOn)
		{
			if (_switchedOnCount < _maxCount)
				_switchedOnCount++;
			else
				_isAlarmOn = false;
		}
	}
}