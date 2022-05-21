namespace Portfolio.Client.Pages.Component.Buttons;

public partial class ButtonGroup
{
	private bool _isVerticalAlign = false;
	private bool _isOverrideStyles = false;
	private string _buttonText = "메뉴";
	private Color _color = Color.Primary;
	private Size _size = Size.Small;
	private Variant _variant = Variant.Filled;

	protected override async Task OnInitializedAsync()
	{
	}

	void SetButtonText(MouseEventArgs args, string text)
	{
		_buttonText = text;
	}
}