using FlaUI.Core.AutomationElements;
using PaintAutomation.Core.Extensions;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.UI.Components;

public class ColorsPanelComponent
{
	private readonly Window _mainWindow;

	public ColorsPanelComponent(Window mainWindow) => _mainWindow = mainWindow;

	public void SelectColor(ColorType color) =>
		_mainWindow.FindFirstDescendant(cf => cf.ByName(color.GetEnumDescription()))?
		.SafeClick();
}
