using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingAlgorithms
{
    public class BitmapWrapper
    {
        public Bitmap bitmap;
        private BitmapData bitmapData;
        private int stride;
        public bool isGrayscale = false;
        public int Width { get; }
        public int Height { get; }
        public Size Size
        {
            get { return new Size(Width, Height); }
        }
        public static int BytesPerPixel
        {
            get { return 4; }
        }

        public Color this[int x, int y]
        {
            get
            {
                //while (x < 0)
                //    x += Width;
                //while (x >= Width)
                //    x -= Width;
                //while (y < 0)
                //    y += Height;
                //while (y >= Height)
                //    y -= Height;

                unsafe
                {
                    int* ptr = ((int*)bitmapData.Scan0) + (y * stride) + x;
                    return Color.FromArgb(*ptr);
                }
            }
            set
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;

                unsafe
                {
                    int* ptr = (int*)(((int*)bitmapData.Scan0) + (y * stride) + x);
                    *ptr = value.ToArgb();
                }
            }
        }

        public byte this[int x, int y, bool b]
        {
            get
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;

                unsafe
                {
                    byte* ptr = (byte*)bitmapData.Scan0 + (y * bitmapData.Stride) + x;
                    return *ptr;
                }
            }
            set
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;

                unsafe
                {
                    byte* ptr = (byte*)bitmapData.Scan0 + (y * bitmapData.Stride) + x;
                    *ptr = value;
                }
            }
        }

        public BitmapWrapper(int width, int height)
        {
            Width = width;
            Height = height;

            bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Lock();
            stride = bitmapData.Stride / BytesPerPixel;
        }

        public BitmapWrapper(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("Bitmap is empty!");
            }

            Width = bitmap.Width;
            Height = bitmap.Height;

            if (bitmap.PixelFormat == PixelFormat.Format32bppArgb)
            {
                this.bitmap = bitmap;
            } 
            else
            {
                this.bitmap = bitmap.Clone(new Rectangle(0, 0, Width, Height), PixelFormat.Format32bppArgb);
            }
                
            Lock();
            stride = bitmapData.Stride / BytesPerPixel;
        }

        public void Draw(Graphics graphics, int x, int y)
        {
            Unlock();
            graphics.DrawImage(bitmap, x, y);
            Lock();
        }

        public void Save(Stream stream, ImageFormat format)
        {
            bitmap.Save(stream, format);
        }

        public void Save(string filename, ImageFormat format)
        {
            bitmap.Save(filename, format);
        }

        public void Lock()
        {
            if (bitmapData != null) { return; }
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        }

        public Bitmap Unlock()
        {
            if (bitmapData == null) { return bitmap; }
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;

            return bitmap;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Unlock();

                if (bitmap != null)
                    bitmap.Dispose();
            }

            bitmapData = null;
            bitmap = null;
        }

        public Graphics CreateGraphics()
        {
            return Graphics.FromImage(bitmap);
        }
    }
}
