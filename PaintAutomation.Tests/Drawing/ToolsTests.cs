using FluentAssertions;
using PaintAutomation.Core.Helpers;
using PaintAutomation.Tests.Base;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.Tests.Drawing;

public class ToolsTests : TestBase
{
	[Test]
	public void VerifyEraserRemovesDrawingFromCanvas()
	{
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "erasedLine.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_eraser_test_{Guid.NewGuid()}.png");

		MainWindow.ShapesPanel.SelectShape(ShapeType.Line);
		MainWindow.Canvas.MoveOnCanvas(100, 100, 400, 400);
		MainWindow.Tools.SelectTool(ToolType.Eraser);
		MainWindow.Canvas.MoveOnCanvas(150, 150, 300, 300);
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("eraser should remove part of the drawing");
	}

	[Test]
	public void VerifyTextToolInsertsTextOnCanvas()
	{
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "text.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_text_test_{Guid.NewGuid()}.png");

		MainWindow.Tools.SelectTool(ToolType.Text);
		MainWindow.Canvas.PlaceTextBlock(200, 200, "Hello Paint!");
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("Text tool should correctly insert text on canvas");
	}

	[Test]
	public void VerifyFillToolFillsAreaWithColor()
	{
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "filledArea.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_fill_test_{Guid.NewGuid()}.png");

		MainWindow.ShapesPanel.SelectShape(ShapeType.RoundedRectangleCallout);
		MainWindow.Canvas.MoveOnCanvas(150, 100, 400, 300);
		MainWindow.Tools.SelectTool(ToolType.Fill);
		MainWindow.ColorsPanel.SelectColor(ColorType.Turquoise);
		MainWindow.Canvas.ClickOnCanvas(200, 200);
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("Fill tool should fill the area with the selected color");
	}

	[Test]
	public void VerifyColorPickerSelectsColor()
	{
		var sourceFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "blueRectangle.png");
		var tempFilePath = Path.Combine(Path.GetTempPath(), $"paint_colorpicker_test_{Guid.NewGuid()}.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_colorpicker_result_{Guid.NewGuid()}.png");
		var expectedFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "colorPicker.png");
		File.Copy(sourceFilePath, tempFilePath, overwrite: true);

		MainWindow.Menu.Open(tempFilePath);
		MainWindow.Tools.SelectTool(ToolType.ColorPicker);
		MainWindow.Canvas.ClickOnCanvas(150, 150);
		MainWindow.ShapesPanel.SelectShape(ShapeType.Line);
		MainWindow.Canvas.MoveOnCanvas(300, 400, 600, 400);

		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("the line should be drawn with the color picked from the rectangle");
	}
}
