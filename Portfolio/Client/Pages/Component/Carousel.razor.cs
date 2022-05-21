namespace Portfolio.Client.Pages.Component;

public partial class Carousel
{
	private bool _arrows = false;
	private bool _bullets = false;
	private bool _autocycle = false;
	private int _selectedIndex = 2;
	private int _autoCycleTimeText = 5;
	private IList<string> _source = new List<string>() { "1", "2", "3", "4", "5" };
	private MudCarousel<string> _carousel;
	private TimeSpan _autoCycleTime = new TimeSpan(0, 0, 0, 5, 0);

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
		int second = Convert.ToInt32(cycleTime);

		_autoCycleTimeText = second;
		_autoCycleTime = new TimeSpan(0, 0, 0, second, 0);
	}
}