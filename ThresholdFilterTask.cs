using System.Collections.Generic;

namespace Recognizer
{
	public static class ThresholdFilterTask
	{
		public static double GetThreshold(double[,] original, double whitePixelsFraction)
		{
			double thresholdT = 0.0;
			var pixelsCount = original.Length;

			var pixels = new List<double>();

			foreach (var e in original)
				pixels.Add(e);

			pixels.Sort();
			
			var whitePixelsCount = (int)(whitePixelsFraction * pixelsCount);
			if (whitePixelsCount > 0 && whitePixelsCount <= pixelsCount)
				thresholdT = pixels[pixelsCount - whitePixelsCount];
			else
				thresholdT = int.MaxValue;

			return thresholdT;
		}


		public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
		{
			var thresholdT = GetThreshold(original, whitePixelsFraction);

			var originalX = original.GetLength(0);
			var originalY = original.GetLength(1);

			for (int x = 0; x < originalX; x++)
			{
				for (int y = 0; y < originalY; y++)
				{
					if (original[x, y] >= thresholdT)
						original[x, y] = 1.0;
					else
						original[x, y] = 0.0;
				}
			}

			return original;
		}
	}
}