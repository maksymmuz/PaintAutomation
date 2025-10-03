using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace PaintAutomation.Core.Driver;

public class AppManager
{
	private static readonly Lazy<AppManager> _instance = new(() => new AppManager());
	public static AppManager Instance => _instance.Value;
	public Application? Application { get; private set; }
	public Window? MainWindow { get; private set; }
	private UIA3Automation? _automation;

	public void Start()
	{
		Application = Application.Launch("mspaint.exe");
		_automation = new UIA3Automation();
		var mainWindow = Application.GetMainWindow(_automation)
			?? throw new InvalidOperationException("Main window could not be found.");

		MainWindow = mainWindow;
		MaximizeWindow();
	}

	public void Stop()
	{
		_automation?.Dispose();
		if (!Application!.HasExited)
			Application.Close();
	}

	public void MaximizeWindow()
	{
		if (MainWindow == null)
			throw new InvalidOperationException("MainWindow is not initialized.");

		MainWindow.Patterns.Window.Pattern
			.SetWindowVisualState(FlaUI.Core.Definitions.WindowVisualState.Maximized);
	}
}
