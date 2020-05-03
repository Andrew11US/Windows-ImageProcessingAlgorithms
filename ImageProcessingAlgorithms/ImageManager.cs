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
    public enum EqualizationMethod { Averages, Random, Neighborhood4, Neighborhood8, Own };
    public enum Operations { Add, Subtract, Multiply, Divide, Difference, AND, OR, XOR };
    public class ImageManager
    {
        public static bool isPixelValid(int x, int y, int width, int height)
        {
            if (x >= 0 && y >= 0 && x < width && y < height) return true;
            return false;
        }

        public static void Grayscale(FastBitmap bmp)
        {
            Color color;
            byte newColor;
            for (int i = 0; i < bmp.Size.Width; ++i)
            {
                for (int j = 0; j < bmp.Size.Height; ++j)
                {
                    color = bmp[i, j];
                    newColor = (byte)Math.Min(0.3 * color.R + 0.59 * color.G + 0.11 * color.B, 255);
                    bmp[i, j] = Color.FromArgb(color.A, newColor, newColor, newColor);
                }
            }
        }

        public static FastBitmap Operation(FastBitmap bmp1, FastBitmap bmp2, Operations op)
        {
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

        public static void GammaCorrect(FastBitmap bmp, int value)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                int pos = (int)((255.0 * Math.Pow(i / 255.0, 1.0 / value)) + 0.5);
                pos = Math.Min(Math.Max(pos, 0), 255);
                upo[i] = (byte)pos;
            }
            ApplyUPO(bmp, upo);
        }

        public static void Binarize(FastBitmap bmp, int low, int high)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < low)
                    upo[i] = 0;
                else if (i >= high)
                    upo[i] = 0;
                else upo[i] = 255;
            }
            ApplyUPO(bmp, upo);
        }

        public static void Binarize2(FastBitmap bmp, int low, int high)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < low)
                    upo[i] = 0;
                else if (i >= high)
                    upo[i] = 0;
                else upo[i] = (byte)i;
            }
            ApplyUPO(bmp, upo);
        }

        public static void Posterize(FastBitmap bmp, int value)
        {
            byte[] upo = new byte[256];
            float param1 = 255.0f / (value - 1);
            float param2 = 256.0f / (value);
            for (int i = 0; i < 256; ++i)
            {
                upo[i] = (byte)((byte)(i / param2) * param1);
            }
            ApplyUPO(bmp, upo);
        }

        public static void Stretch(FastBitmap bmp, int low, int high)
        {
            byte[] upo = new byte[256];
            if ((high - low) <= 0)
            {
                for (int i = 0; i < 256; ++i)
                {
                    upo[i] = 255;
                }
            }
            float parameter = 255.0f / (high - low);
            for (int i = 0; i < 256; ++i)
            {
                if (i < low)
                    upo[i] = 0;
                else if (i >= high)
                    upo[i] = 255;
                else
                    upo[i] = (byte)((i - low) * parameter);
            }
            ApplyUPO(bmp, upo);
        }

        public static List<Color> GetPixelNeighborhood4(FastBitmap bmp, int i, int j)
        {
            List<Color> list = new List<Color>();
            foreach (Point offset in new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) })
            {
                if (i + offset.X >= 0 && i + offset.X < bmp.Width && j + offset.Y >= 0 && j + offset.Y < bmp.Height)
                    list.Add(bmp[i + offset.X, j + offset.Y]);
            }
            return list;
        }

        public static List<Color> GetPixelNeighborhood8(FastBitmap bmp, int i, int j)
        {
            List<Color> list = new List<Color>();
            foreach (Point offset in new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) })
            {
                if (i + offset.X >= 0 && i + offset.X < bmp.Width && j + offset.Y >= 0 && j + offset.Y < bmp.Height)
                    list.Add(bmp[i + offset.X, j + offset.Y]);
            }
            return list;
        }

        public static FastBitmap ApplyMask(FastBitmap bmp, int[,] mask, int divisor)
        {
            FastBitmap bitmap = new FastBitmap((Bitmap)bmp.bitmap.Clone());

            if (divisor == 0)
                divisor = 1;

            int size = mask.GetLength(0) / 2;
            Point[,] temp = new Point[mask.GetLength(0), mask.GetLength(0)];

            for (int i = -size; i <= size; ++i)
                for (int j = -size; j <= size; ++j)
                    temp[i + size, j + size] = new Point(i, j);

            for (int i = size; i < bmp.Width - size; ++i)
            {
                for (int j = size; j < bmp.Height - size; ++j)
                {
                    int newColor = 0;
                    for (int k = 0; k < mask.GetLength(0); ++k)
                    {
                        for (int l = 0; l < mask.GetLength(0); ++l)
                        {
                            Color color = bmp[i + temp[k, l].X, j + temp[k, l].Y];
                            newColor += mask[k, l] * color.R;
                        }
                    }
                    newColor /= divisor;

                    newColor = Math.Max(0, Math.Min(newColor, 255));
                    bitmap[i, j] = Color.FromArgb(255, newColor, newColor, newColor);
                }
            }

            return bitmap;
        }

        public static void ApplyUPO(FastBitmap bmp, byte[] lut)
        {
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

        public static void Thinning(FastBitmap bmp)
        {
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

        public static void Threshold(FastBitmap bmp, int threshold)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < threshold) upo[i] = 0;
                else upo[i] = 255;
            }
            ApplyUPO(bmp, upo);
        }
        public static void ThresholdGrayscale(FastBitmap bmp, int lower, int upper)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < lower || i > upper) upo[i] = 0;
                else upo[i] = (byte)i;
            }
            ApplyUPO(bmp, upo);
        }

        public static void Inversion(FastBitmap bmp)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i) upo[i] = (byte)(255 - i);
            ApplyUPO(bmp, upo);
        }

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
            ApplyUPO(bmp, lut);
        }

        public static void EqualizeHistogram(FastBitmap bmp, Histogram hist, EqualizationMethod method)
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
                switch (method)
                {
                    case EqualizationMethod.Averages:
                        newValue[i] = (int)((left[i] + right[i]) / 2.0);
                        break;
                    case EqualizationMethod.Random:
                        newValue[i] = (int)(right[i] - left[i]);
                        break;
                    case EqualizationMethod.Own:
                        newValue[i] = (int)((left[i] + right[i]) / 2.0);
                        break;
                }
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
                        switch (method)
                        {
                            case EqualizationMethod.Averages:
                                bmp[i, j] = Color.FromArgb(color.A, (int)newValue[color.R], (int)newValue[color.R], (int)newValue[color.R]);
                                break;
                            case EqualizationMethod.Random:
                                Random rnd = new Random();
                                int value = (int)left[color.R] + rnd.Next(newValue[color.R] + 1);
                                bmp[i, j] = Color.FromArgb(color.A, value, value, value);
                                break;
                            case EqualizationMethod.Neighborhood8:
                                double average = 0;
                                int count = 0;
                                foreach (Point offset in new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) })
                                {
                                    if (i + offset.X >= 0 && i + offset.X < bmp.Width && j + offset.Y >= 0 && j + offset.Y < bmp.Height)
                                    {
                                        average += bmp[i + offset.X, j + offset.Y].R;
                                        ++count;
                                    }
                                }
                                average /= count;
                                if (average > right[color.R])
                                    bmp[i, j] = Color.FromArgb(color.A, (int)right[color.R], (int)right[color.R], (int)right[color.R]);
                                else if (average < left[color.R])
                                    bmp[i, j] = Color.FromArgb(color.A, (int)left[color.R], (int)left[color.R], (int)left[color.R]);
                                else
                                    bmp[i, j] = Color.FromArgb(color.A, (int)average, (int)average, (int)average);
                                break;
                            case EqualizationMethod.Own:
                                bmp[i, j] = Color.FromArgb(color.A, (int)newValue[color.R], (int)newValue[color.R], (int)newValue[color.R]);
                                break;
                        }
                    }
                }
            }
        }

        public static Mat ConvertBitmapToMat(Bitmap bmp)
        {
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);

            // data = scan0 is a pointer to our memory block.
            IntPtr data = bmpData.Scan0;

            // step = stride = amount of bytes for a single line of the image
            int step = bmpData.Stride;

            // So you can try to get you Mat instance like this:
            Mat mat = new Mat(bmp.Height, bmp.Width, Emgu.CV.CvEnum.DepthType.Cv32F, 4, data, step);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return mat;
        }

    }


}


        

        