using System.ComponentModel;

namespace PaintAutomation.UI.Enums;

public enum ToolType
{
	[Description("PencilTool")]
	Pencil,

	[Description("FillTool")]
	Fill,

	[Description("TextTool")]
	Text,

	[Description("EraserTool")]
	Eraser,

	[Description("ColorPickerTool")]
	ColorPicker,

	[Description("MagnifierTool")]
	Magnifier
}
