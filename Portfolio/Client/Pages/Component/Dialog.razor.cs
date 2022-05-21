namespace Portfolio.Client.Pages.Component;

public partial class Dialog
{
	private MaxWidth _maxWidth { get; set; } = MaxWidth.False;
	private bool _fullWidth { get; set; } = false;
	private bool _closeButton { get; set; } = true;
	private bool _noHeader { get; set; } = false;
	private bool _disableBackDropClick { get; set; } = true;
	private bool _fullScreen { get; set; } = false;
	private DialogPosition _dialogPosition { get; set; } = DialogPosition.TopCenter;


	private void OpenDialog()
	{
		DialogOptions options = new()
		{
			MaxWidth = _maxWidth,
			FullWidth = _fullWidth,
			CloseButton = _fullScreen ? true : _closeButton,
			NoHeader = _noHeader,
			DisableBackdropClick = _disableBackDropClick,
			FullScreen = _fullScreen,
			Position = _dialogPosition,
			CloseOnEscapeKey = true,
		};

		DialogService.Show<SimpleDialog>("Simple Dialog", options);
	}
}
