using FlaUI.Core.AutomationElements;
using PaintAutomation.Core.Extensions;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.UI.Components;

public class ToolsComponent
{
	private readonly Window _mainWindow;

	public ToolsComponent(Window mainWindow) => _mainWindow = mainWindow;

	public void SelectTool(ToolType tool) =>
		_mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(tool.GetEnumDescription()))?
		.SafeClick();
}
