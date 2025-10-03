using FluentAssertions;
using PaintAutomation.Core.Helpers;
using PaintAutomation.Tests.Base;
using PaintAutomation.UI.Enums;

namespace PaintAutomation.Tests.EditMenu;

public class EditMenuTests : TestBase
{
	[Test]
	public void VerifyUndoRestoresPreviousCanvasState()
	{
		var initialFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "empty.png");
		var tempFilePath = Path.Combine(Path.GetTempPath(), $"paint_undo_test_{Guid.NewGuid()}.png");

		MainWindow.Canvas.MoveOnCanvas(100, 100, 250, 250);
		MainWindow.Menu.Undo();
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, tempFilePath);

		ImageComparer.CompareImagesWithTolerance(initialFilePath, tempFilePath)
			.Should().BeTrue("undo should restore the canvas to its previous state");
	}

	[Test]
	public void VerifyRedoRestoresUndoneDrawing()
	{
		var expectedFilePath = Path.Combine(Path.GetTempPath(), $"paint_redo_expected_{Guid.NewGuid()}.png");
		var actualFilePath = Path.Combine(Path.GetTempPath(), $"paint_redo_actual_{Guid.NewGuid()}.png");

		MainWindow.Canvas.MoveOnCanvas(400, 300, 50, 50);
		MainWindow.Menu.Save(expectedFilePath);
		MainWindow.Menu.Undo();
		MainWindow.Menu.Redo();
		MainWindow.Menu.SaveAs(SaveAsSubItem.Png, actualFilePath);

		ImageComparer.CompareImagesWithTolerance(expectedFilePath, actualFilePath)
			.Should().BeTrue("redo should restore the undone drawing");
	}
}
