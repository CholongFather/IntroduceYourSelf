namespace Portfolio.Client.Components.ThemeManager;

public partial class ThemeButton
{
	[Parameter]
	public EventCallback<MouseEventArgs> OnClick { get; set; }
}