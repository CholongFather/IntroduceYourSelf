namespace Portfolio.Client.Pages.Component;

public partial class Badge
{
	public bool _isBordered;
	public bool _isDot;
	public bool _isOverlap;
	public int? _badgeContent;
	public string _addNumber = "1";
	public string _badgeIcon;
	public string _selectedTestComponent = "Chip";
	public Origin _origin = Origin.TopRight;

	protected override async Task OnInitializedAsync()
	{
	}

	public void OnSelectedTestComponent(string value)
	{
		_selectedTestComponent = value;
	}

	public void AddIcon()
	{
		if (string.IsNullOrWhiteSpace(_badgeIcon))
			_badgeIcon = Icons.Material.Filled.AccessAlarm;
		else
			_badgeIcon = null;
	}

	public void AddValue()
	{
		if (_badgeContent == null)
			_badgeContent = 1;
		else
			_badgeContent += 1;
	}

	public void ClearContent()
	{
		_badgeContent = null;
	}
}