using PaintAutomation.Core.Driver;
using PaintAutomation.UI.Pages;

namespace PaintAutomation.Tests.Base;

public abstract class TestBase
{
	protected MainWindowPage MainWindow { get; private set; }

	[SetUp]
	public void SetUp()
	{
		AppManager.Instance.Start();
		MainWindow = new MainWindowPage(AppManager.Instance.MainWindow!);
	}

	[TearDown]
	public void TearDown()
	{
		AppManager.Instance.Stop();
	}
}
