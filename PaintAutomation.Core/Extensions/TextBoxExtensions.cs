using FlaUI.Core.AutomationElements;

namespace PaintAutomation.Core.Extensions;

public static class TextBoxExtensions
{
	public static void SetTextSafe(this TextBox textBox, string value)
	{
		textBox.Focus();
		textBox.Text = value;
	}
}
