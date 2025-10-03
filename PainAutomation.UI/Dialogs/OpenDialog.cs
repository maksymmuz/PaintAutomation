using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using PaintAutomation.Core.Extensions;

namespace PaintAutomation.UI.Dialogs;

public class OpenDialog
{
	private readonly Window _dialog;

	public OpenDialog(Window dialog) => _dialog = dialog;

	private TextBox? FileNameField => _dialog
		.FindFirstDescendantWait(cf => cf.ByAutomationId("1148"))
		.FindFirstDescendant(cf => cf.ByControlType(ControlType.Edit))
		.AsTextBox();

	public void OpenFile(string fullPath)
	{
		FileNameField?.SetTextSafe(fullPath);
		Keyboard.Press(VirtualKeyShort.RETURN);
		_dialog.WaitUntilClosed();
	}
}
