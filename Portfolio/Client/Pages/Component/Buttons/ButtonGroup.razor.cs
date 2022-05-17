namespace Portfolio.Client.Pages.Component.Buttons;

public partial class ButtonGroup
{
	private Size _size { get; set; } = Size.Small;
	private Variant _variant { get; set; } = Variant.Filled;
	private bool _disable { get; set; } = false;
	private Color _color { get; set; } = Color.Primary;
	private bool _verticalAlign { get; set; } = false;
	private string _buttonText { get; set; } = "메뉴";
	private bool _overrideStyles { get; set; } = false;

	protected override async Task OnInitializedAsync()
	{
	}

	void SetButtonText(MouseEventArgs args, string text)
	{
		_buttonText = text;
	}
}