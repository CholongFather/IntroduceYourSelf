using MudBlazor;

namespace Portfolio.Client.Pages.Component;

public partial class Chips
{
	private Size _size { get; set; } = Size.Small;
	private Variant _variant { get; set; } = Variant.Filled;

	protected override async Task OnInitializedAsync()
	{
	}
}