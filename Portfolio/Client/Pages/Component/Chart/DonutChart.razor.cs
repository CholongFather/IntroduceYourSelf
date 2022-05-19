namespace Portfolio.Client.Pages.Component.Chart;

using MudBlazor;

public partial class DonutChart
{
	private int _selectedIndex = -1;
	private int _dataSize = 4;
	public double[] _chartData;
	public string[] _chartLabels = { "1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월" };

	Random random = new();

	protected override async Task OnInitializedAsync()
{
		await RandomizeData();
	}

	private async Task RandomizeData()
	{
		var data = new double[_dataSize];

		for (var i = 0; i < data.Length; i++)
			data[i] = random.NextDouble() * 100;

		_chartData = data;

		await InvokeAsync(StateHasChanged);
	}

	private async Task AddDataSize()
	{
		if (_dataSize < 12)
		{
			_dataSize = _dataSize + 1;

			await RandomizeData();
		}
	}
	private async Task RemoveDataSize()
	{
		if (_dataSize > 0)
		{
			_dataSize = _dataSize - 1;

			await RandomizeData();
		}
	}
}