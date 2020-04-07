using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingAlgorithms
{
    public class Histogram
    {
        public int[] HistogramTable { get; }
        public int[] HistogramTableRed { get; }
        public int[] HistogramTableGreen { get; }
        public int[] HistogramTableBlue { get; }
        //public int[] CumulatedHistogramTable { get; }
        public int Total { get; } = 0;
        public int Max { get; }
        public double Average { get; }
        public double Mean { get; }
        public double Variance { get; }

        // Additional stuff
        public double Skewness { get; }
        public double Kurtosis { get; }
        public double Entropy { get; }

        public Histogram(BitmapWrapper bmp)
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

            //double[] hv = new double[256];
            //for (int i = 0; i < HistogramTable.Length; ++i)
            //{
            //    hv[i] = (double)HistogramTable[i] / Total;
            //}

            //double temp;

            //Mean = 0;
            //Variance = 0;
            //Skewness = 0;
            //Kurtosis = 0;
            //Entropy = 0;

            //for (int i = 0; i < HistogramTable.Length; ++i)
            //{
            //    Mean += i * hv[i];
            //}

            //for (int i = 0; i < HistogramTable.Length; ++i)
            //{
            //    temp = i - Mean;
            //    Variance += temp * temp * hv[i];
            //    Skewness += temp * temp * temp * hv[i];
            //    Kurtosis += temp * temp * temp * temp * hv[i];
            //    if (hv[i] > 0)
            //        Entropy -= hv[i] * Math.Log(hv[i], Math.E);
            //}
            //temp = Math.Sqrt(Variance);
            //temp = temp * temp * temp;
            //Skewness /= temp;
            //Kurtosis = (Kurtosis / (Variance * Variance)) - 3;
        }
        public Histogram(BitmapWrapper bmp, bool isGrayscale)
        {
            if (isGrayscale)
            {
                HistogramTable = new int[256];
                //CumulatedHistogramTable = new int[256];
                //int cumulatedSum = 0;
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
                // Add max for red, green , blue
                Max = HistogramTable.Max();
                Average = HistogramTable.Average();
            }
        }
    }
}
