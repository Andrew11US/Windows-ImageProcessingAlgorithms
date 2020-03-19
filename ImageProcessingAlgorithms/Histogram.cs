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
        private int[] histogramTable;
        private int total = 0;
        private int max;
        private double avg;
        private double mean;
        private double variance;
        private double skewness;
        private double kurtosis;
        private double entropy;

        public int[] HistogramTable
        {
            get { return histogramTable; }
        }

        public int Total
        {
            get { return total; }
        }

        public int Max
        {
            get { return max; }
        }

        public double Average
        {
            get { return avg; }
        }

        public double Mean
        {
            get { return mean; }
        }

        public double Variance
        {
            get { return variance; }
        }

        public double Skewness
        {
            get { return skewness; }
        }

        public double Kurtosis
        {
            get { return kurtosis; }
        }

        public double Entropy
        {
            get { return entropy; }
        }

        public Histogram(BitmapWrapper bmp)
        {
            histogramTable = new int[256];
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    histogramTable[bmp[i, j].R]++;
                    total++;
                }
            }
            max = histogramTable.Max();
            avg = histogramTable.Average();

            double[] hv = new double[256];
            for (int i = 0; i < histogramTable.Length; ++i)
            {
                hv[i] = (double)histogramTable[i] / total;
            }

            double temp;

            mean = 0;
            variance = 0;
            skewness = 0;
            kurtosis = 0;
            entropy = 0;

            for (int i = 0; i < histogramTable.Length; ++i)
            {
                mean += i * hv[i];
            }

            for (int i = 0; i < histogramTable.Length; ++i)
            {
                temp = i - mean;
                variance += temp * temp * hv[i];
                skewness += temp * temp * temp * hv[i];
                kurtosis += temp * temp * temp * temp * hv[i];
                if (hv[i] > 0)
                    entropy -= hv[i] * Math.Log(hv[i], Math.E);
            }
            temp = Math.Sqrt(variance);
            temp = temp * temp * temp;
            skewness /= temp;
            kurtosis = (kurtosis / (variance * variance)) - 3;
        }
    }
}
