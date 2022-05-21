namespace Portfolio.Client.Pages.Component.Chart;

public partial class BarChart
{
	private int _index = -1;
	private string[] _xAxisLabels = { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" };
	private ChartOptions _chartOptions = new();
	private List<ChartSeries> _series = new();
	private Random _random = new();

	protected override async Task OnInitializedAsync()
	{
		_chartOptions.InterpolationOption = InterpolationOption.NaturalSpline;
		_chartOptions.YAxisFormat = "c2";

		await RandomizeData();
	}

	private async Task RandomizeData()
	{
		var new_series = new List<ChartSeries>()
		{
			new() { Name = "범례 1", Data = new double[12] },
			new() { Name = "범례 2", Data = new double[12] },
			new() { Name = "범례 3", Data = new double[12] },
		};

		for (var i = 0; i < 11; i++)
		{
			new_series[0].Data[i] = _random.NextDouble() * 100;
			new_series[1].Data[i] = _random.NextDouble() * 100;
			new_series[2].Data[i] = _random.NextDouble() * 100;
		}

		_series = new_series;

		await InvokeAsync(StateHasChanged);
	}
}