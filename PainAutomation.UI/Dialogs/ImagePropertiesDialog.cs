using FlaUI.Core.AutomationElements;
using PaintAutomation.Core.Extensions;

namespace PaintAutomation.UI.Dialogs;

public class ImagePropertiesDialog
{
	private readonly Window _dialog;

	public ImagePropertiesDialog(Window dialog) => _dialog = dialog;

	private TextBox WidthBox =>
		_dialog.FindFirstDescendantWait(cf => cf.ByName("Width: Minimum1 Maximum99999"))!.AsTextBox();

	private TextBox HeightBox =>
		_dialog.FindFirstDescendantWait(cf => cf.ByName("Height: Minimum1 Maximum99999"))!.AsTextBox();

	private Button OkButton =>
		_dialog.FindFirstDescendantWait(cf => cf.ByAutomationId("PrimaryButton"))!.AsButton();

	public void SetCanvasSize(int width, int height)
	{
		WidthBox.SetTextSafe(width.ToString());
		HeightBox.SetTextSafe(height.ToString());
		OkButton.Click();
	}
}
