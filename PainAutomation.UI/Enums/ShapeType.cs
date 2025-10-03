using System.ComponentModel;

namespace PaintAutomation.UI.Enums;

public enum ShapeType
{
	[Description("ShapesLineTool")]
	Line,

	[Description("ShapesCurveTool")]
	Curve,

	[Description("ShapesOvalTool")]
	Oval,

	[Description("ShapesRectangleTool")]
	Rectangle,

	[Description("ShapesRoundedRectangleTool")]
	RoundedRectangle,

	[Description("ShapesPolygonTool")]
	Polygon,

	[Description("ShapesTriangleTool")]
	Triangle,

	[Description("ShapesRightTriangleTool")]
	RightTriangle,

	[Description("ShapesDiamondTool")]
	Diamond,

	[Description("ShapesPentagonTool")]
	Pentagon,

	[Description("ShapesHexagonTool")]
	Hexagon,

	[Description("ShapesRightArrowTool")]
	RightArrow,

	[Description("ShapesLeftArrowTool")]
	LeftArrow,

	[Description("ShapesUpArrowTool")]
	UpArrow,

	[Description("ShapesDownArrowTool")]
	DownArrow,

	[Description("ShapesFourPointStarTool")]
	FourPointStar,

	[Description("ShapesFivePointStarTool")]
	FivePointStar,

	[Description("ShapesSixPointStarTool")]
	SixPointStar,

	[Description("ShapesRoundedRectCalloutTool")]
	RoundedRectangleCallout,

	[Description("ShapesOvalCalloutTool")]
	OvalCallout,

	[Description("ShapesCloudCalloutTool")]
	CloudCallout,

	[Description("ShapesHeartTool")]
	Heart,

	[Description("ShapesLightningTool")]
	Lightning
}
