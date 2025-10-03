using FluentAssertions;
using PaintAutomation.Tests.Base;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.Tests.FileMenu;

[TestFixture]
public class FileMenuSaveTests : TestBase
{
	[Test]
	public void VerifySaveAsPngCreatesFile()
	{
		var filePath = Path.Combine(Path.GetTempPath(), $"paint_test_{Guid.NewGuid()}");
		MainWindow.Canvas.MoveOnCanvas(200, 200, 500, 300);
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, filePath);

		File.Exists($"{filePath}.png").Should().BeTrue("SaveAs PNG should create a file with .png extension");
	}

	[Test]
	public void VerifySaveAsJpegCreatesFile()
	{
		var filePath = Path.Combine(Path.GetTempPath(), $"paint_test_{Guid.NewGuid()}");
		MainWindow.Canvas.MoveOnCanvas(100, 100, 400, 400);
		MainWindow.Menu.SaveAs(SaveAsSubItem.Jpeg, filePath);

		File.Exists($"{filePath}.jpg").Should().BeTrue("SaveAs JPEG should create a file with .jpg extension");
	}
}