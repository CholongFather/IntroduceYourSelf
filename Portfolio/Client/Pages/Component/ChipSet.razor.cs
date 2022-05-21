namespace Portfolio.Client.Pages.Component;

public partial class ChipSet
{
	private bool _isMandatory = false;
	private bool _isFilter = false;
	private Color _selectedColor = Color.Primary;
	private Size _size = Size.Small;
	private Variant _variant = Variant.Filled;
	private MudChip selectedMudchip;
	private MudChip[] selectedMudchips;

	protected override async Task OnInitializedAsync()
	{
	}
}