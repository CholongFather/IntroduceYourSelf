namespace Portfolio.Client.Pages.Component.Buttons;

public partial class ToggleIconButton
{
	private bool _alarmOn { get; set; }
	private int _switchedOnCount { get; set; }
	private int _maxCount { get; init; } = 5;

	protected override async Task OnInitializedAsync()
	{
	}

	private async Task OnToggledChanged(bool toggled)
	{
		_alarmOn = toggled;

		if (_alarmOn)
		{
			if (_switchedOnCount < _maxCount)
				_switchedOnCount++;
			else
				_alarmOn = false;
		}
	}
}