namespace Portfolio.Client.Components.Dialog;

public partial class ScrollableDialog
{
	[CascadingParameter]
	MudDialogInstance MudDialog { get; set; }

	void Submit() => MudDialog.Close(DialogResult.Ok(true));
	void Cancel() => MudDialog.Cancel();
}
