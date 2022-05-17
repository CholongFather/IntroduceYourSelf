namespace Portfolio.Client.Pages.Component.Buttons;

public partial class IconButton
{
	private Size _size { get; set; } = Size.Small;
	private Variant _variant { get; set; } = Variant.Filled;
	private bool _disable { get; set; } = false;
	private Color _color { get; set; } = Color.Primary;

	protected override async Task OnInitializedAsync()
	{
	}
}