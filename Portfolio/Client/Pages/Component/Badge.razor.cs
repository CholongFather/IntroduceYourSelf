using MudBlazor;

using static MudBlazor.CategoryTypes;

namespace Portfolio.Client.Pages.Component;

public partial class Badge
{
	public Origin _origin { get; set; } = Origin.TopRight;
	public bool _dot { get; set; }
	public bool _overlap { get; set; }
	public bool _bordered { get; set; }
	public string _badgeIcon { get; set; }

	public string _selectedTestComponent { get; set; } = "Chip";
	public string _addNumber { get; set; } = "1";

	public int? _badgeContent { get; set; }

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
		{
			_badgeIcon = Icons.Custom.Uncategorized.Radioactive;
		}
		else
		{
			_badgeIcon = null;
		}
	}

	public void AddValue()
	{
		if (_badgeContent == null)
		{
			_addNumber = "1";
			_badgeContent = 1;
		}
		else
		{
			_badgeContent += 1;
		}
	}

	public void ClearContent()
	{
		_addNumber = "1";
		_badgeContent = null;
	}
}