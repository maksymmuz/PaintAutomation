using System.Drawing;

namespace PaintAutomation.Core.Helpers;

public static class ImageComparer
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
	public static bool CompareImagesWithTolerance(string expectedPath, string actualPath, int tolerance = 5)
	{
		using var expected = new Bitmap(expectedPath);
		using var actual = new Bitmap(actualPath);

		if (expected.Width != actual.Width || expected.Height != actual.Height)
			return false;

		for (int x = 0; x < expected.Width; x++)
		{
			for (int y = 0; y < expected.Height; y++)
			{
				var ep = expected.GetPixel(x, y);
				var ap = actual.GetPixel(x, y);

				if (Math.Abs(ep.R - ap.R) > tolerance ||
					Math.Abs(ep.G - ap.G) > tolerance ||
					Math.Abs(ep.B - ap.B) > tolerance)
					return false;
			}
		}
		return true;
	}
}
