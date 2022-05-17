using MudBlazor;

namespace Portfolio.Client.Pages.Component;

public partial class Carousel
{
	private MudCarousel<string> _carousel { get; set; }
	private bool _arrows { get; set; } = true;
	private bool _bullets { get; set; } = true;
	private bool _autocycle { get; set; }= true;
	private IList<string> _source { get; set; } = new List<string>() { "1", "2", "3", "4", "5" };
	private int _selectedIndex { get; set; } = 2;
	private int _autoCycleTimeText { get; set; } = 5;
	private TimeSpan _autoCycleTime { get; set; } = new TimeSpan(0,0,0,5,0);

	protected override async Task OnInitializedAsync()
	{
	}

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

	private async Task OnChangeCycleTime(string cycleTime)
	{
		var second = Convert.ToInt32(cycleTime);

		_autoCycleTimeText = second;
		_autoCycleTime = new TimeSpan(0,0,0, second, 0);
	}
}