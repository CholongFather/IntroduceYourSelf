namespace Portfolio.Client.Pages.Component.Buttons;

public partial class Button
{
	private Size _size { get; set; } = Size.Small;
	private Variant _variant { get; set; } = Variant.Filled;
	private int _elevation { get; set; } = 1;
	private bool _disable { get; set; } = false;
	private bool _fullWidth { get; set; } = false;

	protected override async Task OnInitializedAsync()
	{
	}
}