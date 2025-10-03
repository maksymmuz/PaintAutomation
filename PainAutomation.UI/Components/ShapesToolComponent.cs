using FlaUI.Core.AutomationElements;
using PaintAutomation.Core.Extensions;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.UI.Components;

public class ShapesToolComponent
{
	private readonly Window _mainWindow;

	public ShapesToolComponent(Window window) => _mainWindow = window;

	public void SelectShape(ShapeType shape) =>
		_mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(shape.GetEnumDescription()))?
		.SafeClick();
}
