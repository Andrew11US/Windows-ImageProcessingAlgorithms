using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageProcessingAlgorithms
{
    // Method enums
    public enum Operations { Add, Subtract, Multiply, Divide, Difference, AND, OR, XOR };

    // MARK: ImageManager stores custom image processing methods
    public class ImageManager
    {
        // Checking pixel valid image
        public static bool isPixelValid(int x, int y, int width, int height)
        {
            if (x >= 0 && y >= 0 && x < width && y < height) return true;
            return false;
        }

        public static void Grayscale(FastBitmap bmp)
        {
            Color color;
            byte newColor;
            // Loop through image width and height
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    color = bmp[i, j];
                    // Assing value propationaly to every channel
                    newColor = (byte)Math.Min(0.3 * color.R + 0.59 * color.G + 0.11 * color.B, 255);
                    bmp[i, j] = Color.FromArgb(color.A, newColor, newColor, newColor);
                }
            }
        }

        // Point operations
        public static FastBitmap Operation(FastBitmap bmp1, FastBitmap bmp2, Operations op)
        {
            // Combining two images
            FastBitmap bmp = new FastBitmap(Math.Max(bmp1.Width, bmp2.Width), Math.Max(bmp1.Height, bmp2.Height));
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    Color c1;
                    Color c2;
                    if (isPixelValid(i, j, bmp1.Width, bmp1.Height))
                        c1 = bmp1[i, j];
                    else
                        c1 = Color.Black;
                    if (isPixelValid(i, j, bmp2.Width, bmp2.Height))
                        c2 = bmp2[i, j];
                    else
                        c2 = Color.Black;
                    // Switching through operations and performing last one
                    switch (op)
                    {
                        case Operations.Add:
                            bmp[i, j] = Color.FromArgb(255, Math.Min(255, c1.R + c2.R), Math.Min(255, c1.G + c2.G), Math.Min(255, c1.B + c2.B));
                            break;
                        case Operations.Subtract:
                            bmp[i, j] = Color.FromArgb(255, Math.Max(0, c1.R - c2.R), Math.Max(0, c1.G - c2.G), Math.Max(0, c1.B - c2.B));
                            break;
                        case Operations.Multiply:
                            bmp[i, j] = Color.FromArgb(255, Math.Min(255, c1.R * c2.R), Math.Min(255, c1.G * c2.G), Math.Min(255, c1.B * c2.B));
                            break;
                        case Operations.Divide:
                            bmp[i, j] = Color.FromArgb(255, c1.R / Math.Max((byte)1, c2.R), c1.G / Math.Max((byte)1, c2.G), c1.B / Math.Max((byte)1, c2.B));
                            break;
                        case Operations.Difference:
                            bmp[i, j] = Color.FromArgb(255, Math.Abs(c1.R - c2.R), Math.Abs(c1.G - c2.G), Math.Abs(c1.B - c2.B));
                            break;
                        case Operations.AND:
                            bmp[i, j] = Color.FromArgb(255, Math.Max(0, Math.Min(255, c1.R & c2.R)), Math.Max(0, Math.Min(255, c1.G & c2.G)), Math.Max(0, Math.Min(255, c1.B & c2.B)));
                            break;
                        case Operations.OR:
                            bmp[i, j] = Color.FromArgb(255, Math.Max(0, Math.Min(255, c1.R | c2.R)), Math.Max(0, Math.Min(255, c1.G | c2.G)), Math.Max(0, Math.Min(255, c1.B | c2.B)));
                            break;
                        case Operations.XOR:
                            bmp[i, j] = Color.FromArgb(255, Math.Max(0, Math.Min(255, c1.R ^ c2.R)), Math.Max(0, Math.Min(255, c1.G ^ c2.G)), Math.Max(0, Math.Min(255, c1.B ^ c2.B)));
                            break;
                    }
                }
            }
            return bmp;
        }

        // Posterization
        public static void Posterize(FastBitmap bmp, int value)
        {
            // initializing lut
            byte[] lut = new byte[256];
            float param1 = 255.0f / (value - 1);
            float param2 = 256.0f / (value);
            // Loop throght image and creating new lut
            for (int i = 0; i < 256; ++i)
            {
                lut[i] = (byte)((byte)(i / param2) * param1);
            }
            // applying lut to the image
            ApplyLUT(bmp, lut);
        }

        // Histogram stretching
        public static void Stretch(FastBitmap bmp, int low, int high)
        {
            // initializing lut
            byte[] lut = new byte[256];
            if ((high - low) <= 0)
            {
                for (int i = 0; i < 256; ++i)
                {
                    lut[i] = 255;
                }
            }
            float parameter = 255.0f / (high - low);
            for (int i = 0; i < 256; ++i)
            {
                if (i < low)
                    lut[i] = 0;
                else if (i >= high)
                    lut[i] = 255;
                else
                    lut[i] = (byte)((i - low) * parameter);
            }
            ApplyLUT(bmp, lut);
        }

        // MARK: - Apply Look up table method
        public static void ApplyLUT(FastBitmap bmp, byte[] lut)
        {
            // Looping and assigning new value to fastBitmap image
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    Color color = bmp[i, j];
                    byte newColor = lut[color.R];
                    bmp[i, j] = Color.FromArgb(color.A, newColor, newColor, newColor);
                }
            }
        }

        // Thinning (Skeletonization) method
        public static void Thinning(FastBitmap bmp)
        {
            // Init edge operators
            int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dy = { 1, 1, 0, -1, -1, -1, 0, 1 };
            
            bool[,] img = new bool[bmp.Width, bmp.Height];
            int W = bmp.Width;
            int H = bmp.Height;
            for (int i = 0; i < bmp.Width; ++i)
            {
                for (int j = 0; j < bmp.Height; ++j)
                {
                    img[i, j] = bmp[i, j].B < 128;
                }
            }

            bool pass = false;
            LinkedList<Point> list;
            do
            {
                pass = !pass;
                list = new LinkedList<Point>();

                for (int x = 1; x < W - 1; ++x)
                {
                    for (int y = 1; y < H - 1; ++y)
                    {
                        if (img[x, y])
                        {
                            int cnt = 0;
                            int hm = 0;
                            bool prev = img[x - 1, y + 1];
                            for (int i = 0; i < 8; ++i)
                            {
                                bool cur = img[x + dx[i], y + dy[i]];
                                hm += cur ? 1 : 0;
                                if (prev && !cur) ++cnt;
                                prev = cur;
                            }
                            if (hm > 1 && hm < 7 && cnt == 1)
                            {
                                if (pass && (!img[x + 1, y] || !img[x, y + 1] || !img[x, y - 1] && !img[x - 1, y]))
                                {
                                    list.AddLast(new Point(x, y));
                                }
                                if (!pass && (!img[x - 1, y] || !img[x, y - 1] || !img[x, y + 1] && !img[x + 1, y]))
                                {
                                    list.AddLast(new Point(x, y));
                                }
                            }
                        }

                    }
                }
                foreach (Point p in list)
                {
                    img[p.X, p.Y] = false;
                }
            } while (list.Count != 0);

            for (int x = 0; x < W; ++x)
            {
                for (int y = 0; y < H; ++y)
                {
                    bmp[x, y] = img[x, y] ? Color.Black : Color.White;
                }
            }
        }

        // Binary thresholding
        public static void Threshold(FastBitmap bmp, int threshold)
        {
            byte[] lut = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < threshold) lut[i] = 0;
                else lut[i] = 255;
            }
            ApplyLUT(bmp, lut);
        }

        // Threshold with grayscale
        public static void ThresholdGrayscale(FastBitmap bmp, int lower, int upper)
        {
            byte[] lut = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < lower || i > upper) lut[i] = 0;
                else lut[i] = (byte)i;
            }
            ApplyLUT(bmp, lut);
        }

        // Inversion
        public static void Inversion(FastBitmap bmp)
        {
            byte[] lut = new byte[256];
            for (int i = 0; i < 256; ++i) lut[i] = (byte)(255 - i);
            ApplyLUT(bmp, lut);
        }

        // Contrast enhancement
        public static void AdjustHistogram(FastBitmap bmp, Histogram histogram)
        {
            byte[] d = new byte[256];
            byte[] lut = new byte[256];
            double cumulatedValue = 0.0;

            for (int i = 0; i < 256; ++i)
            {
                cumulatedValue += histogram.HistogramTable[i];
                d[i] = (byte)(cumulatedValue / (i + 1));
            }

            for (int j = 0; j < 256; ++j)
            {
                lut[j] = (byte)((d[j] - d[0]) / (1 - d[0]) * 255);
            }
            ApplyLUT(bmp, lut);
        }

        // Histogrma equalization
        public static void EqualizeHistogram(FastBitmap bmp, Histogram hist)
        {
            int R = 0;
            double hInt = 0.0;
            double[] left = new double[256];
            double[] right = new double[256];
            int[] newValue = new int[256];

            for (int i = 0; i < 256; ++i)
            {
                left[i] = R;
                hInt += hist.HistogramTable[i];
                while (hInt > hist.Average)
                {
                    hInt -= hist.Average;
                    if (R < 255)
                        R++;
                }

                right[i] = R;
                newValue[i] = (int)((left[i] + right[i]) / 2.0);
            }

            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    Color color = bmp[i, j];
                    if (left[color.R] == right[color.R])
                        bmp[i, j] = Color.FromArgb(color.A, (int)left[color.R], (int)left[color.R], (int)left[color.R]);
                    else
                    {
                        bmp[i, j] = Color.FromArgb(color.A, (int)newValue[color.R], (int)newValue[color.R], (int)newValue[color.R]);
                    }
                }
            }
        }
    }

}


        

        