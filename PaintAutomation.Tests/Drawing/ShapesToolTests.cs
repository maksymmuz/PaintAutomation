using FluentAssertions;
using PaintAutomation.Core.Helpers;
using PaintAutomation.Tests.Base;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.Tests.Drawing;

public class ShapesToolTests : TestBase
{
	[Test]
	public void VerifyRectangleDrawsCorrectShape()
	{
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "rectangle.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_rectangle_test_{Guid.NewGuid()}.png");

		MainWindow.ShapesPanel.SelectShape(ShapeType.Rectangle);
		MainWindow.Canvas.MoveOnCanvas(50, 50, 320, 380);
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("rectangle tool should draw a correct rectangle");
	}

	[Test]
	public void VerifyPentagonDrawsCorrectShape()
	{
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "pentagon.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_pentagon_test_{Guid.NewGuid()}.png");

		MainWindow.ShapesPanel.SelectShape(ShapeType.Pentagon);
		MainWindow.Canvas.MoveOnCanvas(120, 50, 530, 450);
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("pentagon tool should draw a correct pentagon");
	}

	[Test]
	public void VerifyLineDrawsCorrectShape()
	{
		var filePath = Path.Combine(Path.GetTempPath(), $"paint_test_{Guid.NewGuid()}.png");
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "threeLines.png");

		MainWindow.Canvas.MoveOnCanvas(100, 100, 500, 100);
		MainWindow.Canvas.MoveOnCanvas(500, 100, 500, 400);
		MainWindow.Canvas.MoveOnCanvas(500, 400, 100, 100);
		MainWindow.Menu.Save(filePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, filePath)
			.Should().BeTrue("the drawn line should be saved correctly to the file");
	}
}
