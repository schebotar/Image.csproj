using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		public static double[,] GetFramedImage(double[,] notFramed)
		{
			var xLength = notFramed.GetLength(0);
			var yLength = notFramed.GetLength(1);
			var framedOriginal = new double[xLength + 2, yLength + 2];			

			for (int x = 0; x < xLength + 2; x++)
			{
				for (int y = 0; y < yLength + 2; y++)
					framedOriginal[x, y] = -1;
			}

			for (int x = 0; x < xLength; x++)
			{
				for (int y = 0; y < yLength; y++)
					framedOriginal[x + 1, y + 1] = notFramed[x, y];
			}
			return framedOriginal;
		}

		public static List<double> GetListOfValues(int x, int y, double[,] framedOriginal)
		{
			var pixelValues = new List<double>();

			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					if (framedOriginal[x + i, y + j] != -1)
						pixelValues.Add(framedOriginal[x + i, y + j]);
				}				
			}
			return pixelValues;
		}

		public static double GetMedian(List<double> pixelValues)
		{
			double median = 0.0;
			pixelValues.Sort();
			if (pixelValues.Count % 2 == 1)
				median = pixelValues[(pixelValues.Count + 1) / 2 - 1];
			else
				median = (pixelValues[pixelValues.Count / 2 - 1] + pixelValues[pixelValues.Count / 2]) / 2;			
			return median;
		}

		public static double[,] MedianFilter(double[,] original)
		{
			var framedOriginal = GetFramedImage(original);
			var framedXLength = framedOriginal.GetLength(0);
			var framedYLength = framedOriginal.GetLength(1);
			var result = new double[original.GetLength(0), original.GetLength(1)];

			for (int x = 1; x < framedXLength - 1; x++)
			{
				for (int y = 1; y < framedYLength - 1; y++)
				{
					var pixelValues = GetListOfValues(x, y, framedOriginal);
					var median = GetMedian(pixelValues);
					result[x - 1, y - 1] = median;
				}
			}
			return result;
		}
	}
}