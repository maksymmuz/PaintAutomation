using FlaUI.Core.AutomationElements;
using PaintAutomation.Core.Extensions;

namespace PaintAutomation.UI.Dialogs;

public class SaveDialog
{
	private readonly Window _dialog;

	public SaveDialog(Window dialog) => _dialog = dialog;

	private TextBox? FileNameField =>
		_dialog.FindFirstDescendantWait(cf => cf.ByAutomationId("1001")).AsTextBox();

	private AutomationElement? SaveButton =>
		_dialog.FindFirstDescendantWait(cf => cf.ByName("Save"));

	public void SaveFile(string fullPath)
	{
		FileNameField?.SetTextSafe(fullPath);
		SaveButton?.SafeClick();
		_dialog.WaitUntilClosed();
	}
}
