using FlaUI.Core.Input;
using System.Drawing;

namespace PaintAutomation.Core.Helpers;

public static class MouseHelper
{
	public static void DragAndDrop(Point start, Point end)
	{
		Mouse.MoveTo(start);
		Mouse.Down(MouseButton.Left);
		Mouse.MoveTo(end);
		Mouse.Up(MouseButton.Left);
	}
}
