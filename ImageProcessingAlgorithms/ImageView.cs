using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageProcessingAlgorithms
{
    public partial class ImageView : Form
    {
        // Variable declarations
        public string path;
        public FastBitmap bitmap;
        public string FileName => Path.GetFileName(path);
        public Histogram Histogram => new Histogram(bitmap, false);
        public Mat Mat { get; private set; }
        public FastBitmap image
        {
            get => bitmap;
            set => bitmap = value;
        }

        // Initialization with path
        public ImageView(string path)
        {
            InitializeComponent();
            
            try
            {
                // UI setup
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                bitmap = new FastBitmap((Bitmap)Image.FromFile(path));
                pictureBox.Left = 0;
                pictureBox.Top = 0;
                ClientSize = bmp.Size;
                Text = Path.GetFileName(path);
                pictureBox.Image = bmp;

                this.path = path;
                Mat = CvInvoke.Imread(path);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error creating bitmap!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        // Initialization with bitmap
        public ImageView(Bitmap b)
        {
            InitializeComponent();

            try
            {
                Bitmap bmp = b;
                bitmap = new FastBitmap((Bitmap)bmp.Clone());
                pictureBox.Left = 0;
                pictureBox.Top = 0;
                ClientSize = bmp.Size;
                Text = GetHash(bmp.ToString());   
                pictureBox.Image = bmp;

                Image<Bgr, byte> img = bmp.ToImage<Bgr, byte>();
                Mat = img.Mat;
                this.path = "";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error creating bitmap!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void setImage(Bitmap bmp)
        {
            // Getting Mat from bitmap
            Image<Bgr, byte> img = bmp.ToImage<Bgr, byte>();
            Mat = img.Mat;

            pictureBox.Image = null;
            pictureBox.Image = bmp;
            bitmap = new FastBitmap((Bitmap)bmp.Clone());
        }

        public void setImage(Mat mat)
        {
            // Setting Mat object and populating to imageView
            Mat = mat;
            pictureBox.Image = null;
            pictureBox.Image = (Bitmap)mat.ToBitmap().Clone();
            bitmap = new FastBitmap((Bitmap)mat.ToBitmap().Clone());
        }

        // Save image method
        public void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save an Image to File";
            // Formats
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|GIF Image|*.gif|BMP Image|*.bmp|TIFF Image|*.tiff";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageFormat format = ImageFormat.Jpeg;
                int width = Convert.ToInt32(bitmap.Width);
                int height = Convert.ToInt32(bitmap.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));

                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        format = ImageFormat.Jpeg;
                        break;
                    case 2:
                        format = ImageFormat.Png;
                        break;
                    case 3:
                        format = ImageFormat.Gif;
                        break;
                    case 4:
                        format = ImageFormat.Bmp;
                        break;
                    case 5:
                        format = ImageFormat.Tiff;
                        break;
                }

                bmp.Save(saveFileDialog.FileName, format);
            }
        }

        // Gets Hash from Image using SHA256 hashing algorithm
        private static string GetHash(string input)
        {
            // Creates SHA256 Hash from input and adds random Int to make output unique
            Random rand = new Random();
            var sBuilder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input+rand.Next(0,100)));
                for (int i = 0; i < 5; i++) sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
