using MudBlazor;

namespace Portfolio.Client.Pages.Component;

public partial class Carousel
{
	private MudCarousel<string> _carousel;
	private bool _arrows = true;
	private bool _bullets = true;
	private bool _autocycle = true;
	private IList<string> _source = new List<string>() { "1", "2", "3", "4", "5" };
	private int _selectedIndex = 2;
	private TimeSpan _autoCycleTime = new TimeSpan(0,0,0,5,0);

	private async Task AddAsync()
	{
		_source.Add($"{_source.Count + 1}");

		await Task.Delay(1);

		_carousel.MoveTo(_source.Count - 1);
	}

	private async Task DeleteAsync(int index)
	{
		if (_source.Any())
		{
			_source.RemoveAt(index);

			await Task.Delay(1);

			_carousel.MoveTo(Math.Max(Math.Min(index, _source.Count - 1), 0));
		}
	}

	protected override async Task OnInitializedAsync()
	{
	}
}