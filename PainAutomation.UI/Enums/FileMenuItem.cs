using System.ComponentModel;

namespace PaintAutomation.UI.Enums;

public enum FileMenuItem
{
	[Description("FileNew")]
	New,

	[Description("FileOpen")]
	Open,

	[Description("ImportToCanvas")]
	ImportToCanvas,

	[Description("RecentFiles")]
	RecentFiles,

	[Description("FileSave")]
	Save,

	[Description("FileSaveAs")]
	SaveAs,

	[Description("Print")]
	Print,

	[Description("Share")]
	Share,

	[Description("DesktopBackground")]
	DesktopBackground,

	[Description("ImageProperties")]
	ImageProperties,

	[Description("Exit")]
	Exit
}
