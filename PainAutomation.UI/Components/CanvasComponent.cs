using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using PaintAutomation.Core.Extensions;
using PaintAutomation.Core.Helpers;
using System.Drawing;

namespace PaintAutomation.UI.Components;

public class CanvasComponent
{
	private readonly Window _mainWindow;

	public CanvasComponent(Window mainWindow) => _mainWindow = mainWindow;

	private AutomationElement CanvasElement =>
		_mainWindow.FindFirstDescendantWait(cf => cf.ByAutomationId("image"));

	public void MoveOnCanvas(int startX, int startY, int endX, int endY)
	{
		var bounds = CanvasElement.BoundingRectangle;

		if (startX < 0 || startY < 0 || endX < 0 || endY < 0 ||
			startX > bounds.Width || endX > bounds.Width ||
			startY > bounds.Height || endY > bounds.Height)
		{
			throw new ArgumentOutOfRangeException("Line coordinates must be within canvas bounds.");
		}

		CanvasElement.RightClick();
		var startPoint = new Point(bounds.Left + startX, bounds.Top + startY);
		var endPoint = new Point(bounds.Left + endX, bounds.Top + endY);
		MouseHelper.DragAndDrop(startPoint, endPoint);
	}

	public void PlaceTextBlock(int x, int y, string text)
	{
		MoveOnCanvas(x, y, x, y);
		Keyboard.Type(text);
	}

	public void ClickOnCanvas(int x, int y)
	{
		var bounds = CanvasElement.BoundingRectangle;
		var point = new Point(bounds.Left + x, bounds.Top + y);
		CanvasElement.RightClick();
		Mouse.MoveTo(point);
		Mouse.Click();
	}
}
