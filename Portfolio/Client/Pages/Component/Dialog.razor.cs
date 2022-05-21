namespace Portfolio.Client.Pages.Component;

public partial class Dialog
{
	private bool _isFullWidth = false;
	private bool _isCloseButton = false;
	private bool _hasHeader = false;
	private bool _backDropClick = false;
	private bool _isFullScreen = false;
	private DialogPosition _dialogPosition = DialogPosition.TopCenter;
	private MaxWidth _maxWidth = MaxWidth.False;


	private void OpenDialog()
	{
		DialogOptions options = new()
		{
			MaxWidth = _maxWidth,
			FullWidth = _isFullWidth,
			CloseButton = _isFullScreen ? true : _isCloseButton,
			NoHeader = _hasHeader,
			DisableBackdropClick = _backDropClick,
			FullScreen = _isFullScreen,
			Position = _dialogPosition,
			CloseOnEscapeKey = true,
		};

		DialogService.Show<SimpleDialog>("Simple Dialog", options);
	}
}
