using MudBlazor;

namespace Portfolio.Client.Pages.Component;

public partial class ChipSet
{
	private bool _mandatory { get; set; } = false;
	private bool _filter { get; set; } = false;
	private Size _size { get; set; } = Size.Small;
	private Variant _variant { get; set; } = Variant.Filled;
	private Color _selectedColor { get; set; } = Color.Primary;
	private MudChip selectedMudchip { get; set; }
	private MudChip[] selectedMudchips { get; set; }

	protected override async Task OnInitializedAsync()
	{
	}
}