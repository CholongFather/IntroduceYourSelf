namespace Portfolio.Client.Pages.Component.Buttons;

public partial class ButtonFab
{
	private Size _size { get; set; } = Size.Small;
	private bool _disable { get; set; } = false;
	private string _text { get; set; }

	protected override async Task OnInitializedAsync()
	{
	}
}