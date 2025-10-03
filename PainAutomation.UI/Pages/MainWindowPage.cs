using FlaUI.Core.AutomationElements;
using PaintAutomation.UI.Components;

namespace PaintAutomation.UI.Pages;

public class MainWindowPage
{
	private readonly Window? _mainWindow;
	public MenuBarComponent Menu { get; }
	public ShapesToolComponent ShapesPanel { get; }
	public CanvasComponent Canvas { get; }
	public ToolsComponent Tools { get; }
	public ColorsPanelComponent ColorsPanel { get; }

	public MainWindowPage(Window mainWindow)
	{
		_mainWindow = mainWindow;
		Menu = new MenuBarComponent(_mainWindow);
		ShapesPanel = new ShapesToolComponent(_mainWindow);
		Canvas = new CanvasComponent(_mainWindow);
		Tools = new ToolsComponent(_mainWindow);
		ColorsPanel = new ColorsPanelComponent(_mainWindow);

		ResizeCanvasToDefault();
	}

	public void ResizeCanvasToDefault() =>
		Menu.OpenImageProperties().SetCanvasSize(800, 600);
}
