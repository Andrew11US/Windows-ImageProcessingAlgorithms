using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingAlgorithms
{
    // Histogram class to store histogrma across app
    public class Histogram
    {
        // Variables
        public int[] HistogramTable { get; }
        public int[] HistogramTableRed { get; }
        public int[] HistogramTableGreen { get; }
        public int[] HistogramTableBlue { get; }
        public int Total { get; } = 0;
        public int Max { get; }
        public double Average { get; }

        // Calculating from fastBitmap depending if image is grayscale
        public Histogram(FastBitmap bmp, bool isGrayscale)
        {
            if (isGrayscale)
            {
                HistogramTable = new int[256];
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        HistogramTable[bmp[i, j].R]++;
                        Total++;
                    }
                }

                Max = HistogramTable.Max();
                Average = HistogramTable.Average();
            }
            else
            {
                // Calculating RGB histogram values
                HistogramTable = new int[256];
                HistogramTableRed = new int[256];
                HistogramTableGreen = new int[256];
                HistogramTableBlue = new int[256];
                for (int i = 0; i < bmp.Size.Width; ++i)
                {
                    for (int j = 0; j < bmp.Size.Height; ++j)
                    {
                        HistogramTable[bmp[i, j].R]++;
                        HistogramTableRed[bmp[i, j].R]++;
                        HistogramTableGreen[bmp[i, j].G]++;
                        HistogramTableBlue[bmp[i, j].B]++;
                        Total++;
                    }
                }
                Max = HistogramTable.Max();
                Average = HistogramTable.Average();
            }
        }
    }
}
