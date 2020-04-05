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

        public static void Grayscale(BitmapWrapper bmp)
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

        //public static BitmapWrapper Turtle(BitmapWrapper bitmap)
        //{
        //    BitmapWrapper bmp = new BitmapWrapper((Bitmap)(bitmap.bitmap.Clone()));
        //    int[,] rtab = new int[bmp.Width, bmp.Height];
        //    int[,] gtab = new int[bmp.Width, bmp.Height];
        //    int[,] btab = new int[bmp.Width, bmp.Height];
        //    int i, j;
        //    for (i = 1; i < bmp.Width - 1; i++)
        //    {
        //        for (j = 1; j < bmp.Height - 1; j++)
        //        {
        //            rtab[i, j] = bmp[i, j].R;
        //            gtab[i, j] = bmp[i, j].G;
        //            btab[i, j] = bmp[i, j].B;
        //        }
        //    }
        //    int d = 0;
        //    int pami = 0, pamj = 0, ja = 0, ia = 0;
        //    int x, y;
        //    int[] wynik = new int[bmp.Width * bmp.Height];
        //    int[] droga = new int[bmp.Width * bmp.Height];
        //    for (i = 1; i < bmp.Height - 1; i++)
        //    {
        //        for (j = 1; j < bmp.Width - 1; j++)
        //        {
        //            if (rtab[j, i] != 0 || gtab[j, i] != 0 || btab[j, i] != 0)
        //            {
        //                ja = j;
        //                ia = i;
        //                pamj = j;
        //                pami = i;
        //                wynik[bmp.Width * i + j] = 255;
        //                goto cont;
        //            }
        //        }
        //    }
        //cont:
        //    j = pamj;
        //    i = pami - 1;
        //    wynik[bmp.Width * i + j] = 255;
        //    droga[d] = 1;
        //    do
        //    {
        //        x = j - pamj;
        //        y = i - pami;
        //        pamj = j;
        //        pami = i;
        //        d++;
        //        if (rtab[j, i] != 0 || gtab[j, i] != 0 || btab[j, i] != 0)
        //        {
        //            if (x == 0 && y == (-1))
        //            {
        //                j--;
        //                droga[d] = 2;
        //            }
        //            if (x == 1 && y == 0)
        //            {
        //                i--;
        //                droga[d] = 1;
        //            }
        //            if (x == 0 && y == 1)
        //            {
        //                j++;
        //                droga[d] = 0;
        //            }
        //            if (x == (-1) && y == 0)
        //            {
        //                i++;
        //                droga[d] = 3;
        //            }
        //        }
        //        else
        //        {
        //            if (x == 0 && y == (-1))
        //            {
        //                j++;
        //                droga[d] = 0;
        //            }
        //            if (x == 1 && y == 0)
        //            {
        //                i++;
        //                droga[d] = 3;
        //            }
        //            if (x == 0 && y == 1)
        //            {
        //                j--;
        //                droga[d] = 2;
        //            }
        //            if (x == (-1) && y == 0)
        //            {
        //                i--;
        //                droga[d] = 1;
        //            }
        //        }
        //        wynik[bmp.Width * i + j] = 255;
        //    }
        //    while (j != ja || i != ia);
        //    for (i = 0; i < bmp.Height; i++)
        //    {
        //        for (j = 0; j < bmp.Width; j++)
        //        {
        //            if (wynik[bmp.Width * i + j] == 255)
        //            {
        //                rtab[j, i] = 255;
        //                gtab[j, i] = 0;
        //                btab[j, i] = 0;
        //            }
        //        }
        //    }

        //    for (i = 0; i < bmp.Width; i++)
        //    {
        //        for (j = 0; j < bmp.Height; j++)
        //        {
        //            bmp[i, j] = Color.FromArgb(rtab[i, j], gtab[i, j], btab[i, j]);
        //        }
        //    }
        //    return bmp;
        //}

        public static BitmapWrapper Hide(BitmapWrapper bmp1, BitmapWrapper bmp2)
        {
            BitmapWrapper bmpSecret = new BitmapWrapper((Bitmap)bmp2.bitmap.Clone());
            Threshold(bmpSecret, 127);
            BitmapWrapper bmp = new BitmapWrapper(bmp1.Width, bmp1.Height);

            for (int i = 0; i < bmp1.Width; ++i)
            {
                for (int j = 0; j < bmp1.Height; ++j)
                {
                    int newColor = bmp1[i, j].R & (0xFE);
                    if (i < bmpSecret.Width && j < bmpSecret.Height)
                        newColor |= bmpSecret[i, j].R == 0 ? 0x00 : 0x01;
                    bmp[i, j] = Color.FromArgb(newColor, newColor, newColor);
                }
            }

            return bmp;
        }

        public static BitmapWrapper Recover(BitmapWrapper bmp)
        {
            BitmapWrapper bmpRecovered = new BitmapWrapper(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int newColor = (bmp[i, j].R & 0x01) == 0x01 ? 255 : 0;
                    bmpRecovered[i, j] = Color.FromArgb(newColor, newColor, newColor);
                }
            }

            return bmpRecovered;
        }

        public static BitmapWrapper Operation(BitmapWrapper bmp1, BitmapWrapper bmp2, Operations op)
        {
            BitmapWrapper bmp = new BitmapWrapper(Math.Max(bmp1.Width, bmp2.Width), Math.Max(bmp1.Height, bmp2.Height));
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

        public static void GammaCorrect(BitmapWrapper bmp, int value)
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

        public static void Binarize(BitmapWrapper bmp, int low, int high)
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

        public static void Binarize2(BitmapWrapper bmp, int low, int high)
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

        public static void Posterize(BitmapWrapper bmp, int value)
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

        public static void Stretch(BitmapWrapper bmp, int low, int high)
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
                    upo[i] = 0;
                else
                    upo[i] = (byte)((i - low) * parameter);
            }
            ApplyUPO(bmp, upo);
        }

        public static List<Color> GetPixelNeighborhood4(BitmapWrapper bmp, int i, int j)
        {
            List<Color> list = new List<Color>();
            foreach (Point offset in new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) })
            {
                if (i + offset.X >= 0 && i + offset.X < bmp.Width && j + offset.Y >= 0 && j + offset.Y < bmp.Height)
                    list.Add(bmp[i + offset.X, j + offset.Y]);
            }
            return list;
        }

        public static List<Color> GetPixelNeighborhood8(BitmapWrapper bmp, int i, int j)
        {
            List<Color> list = new List<Color>();
            foreach (Point offset in new Point[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(-1, -1), new Point(-1, 1), new Point(1, -1) })
            {
                if (i + offset.X >= 0 && i + offset.X < bmp.Width && j + offset.Y >= 0 && j + offset.Y < bmp.Height)
                    list.Add(bmp[i + offset.X, j + offset.Y]);
            }
            return list;
        }

        public static BitmapWrapper ApplyMask(BitmapWrapper bmp, int[,] mask, int divisor)
        {
            BitmapWrapper bitmap = new BitmapWrapper((Bitmap)bmp.bitmap.Clone());

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

        public static void ApplyUPO(BitmapWrapper bmp, byte[] lut)
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

        public static void Thinning(BitmapWrapper bmp)
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

        public static void Threshold(BitmapWrapper bmp, int threshold)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                if (i < threshold)
                    upo[i] = 0;
                else upo[i] = 255;
            }
            ApplyUPO(bmp, upo);
        }

        public static void Negation(BitmapWrapper bmp)
        {
            byte[] upo = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                int newValue = 255 - i;
                upo[i] = (byte)newValue;
               
            }
            ApplyUPO(bmp, upo);
        }

        public static void EqualizeHistogram(BitmapWrapper bmp, Histogram hist, EqualizationMethod method)
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

    }
}


        

        