using System.ComponentModel;

namespace PaintAutomation.UI.Enums;

public enum SaveAsSubItem
{
	[Description("PNG picture")]
	Png,

	[Description("JPEG picture")]
	Jpeg,

	[Description("BMP picture")]
	Bmp,

	[Description("GIF picture")]
	Gif,

	[Description("Other format")]
	Other
}
