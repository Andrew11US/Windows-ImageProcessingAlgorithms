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

namespace ImageProcessingAlgorithms
{
    public partial class ImageView : Form
    {
        // Variables declarations
        public string path;
        public FastBitmap bitmap;
        private Graphics graphics;
        public bool imageChanged = false;
        public int ChildID { get; set; }
        public string FileName
        {
            get { return Path.GetFileName(path); }
        }
        public Histogram Histogram
        {
            get { return new Histogram(bitmap, false); }
        }
        public FastBitmap image
        {
            get => bitmap;
            set => bitmap = value;
        }

        public ImageView()
        {
            InitializeComponent();
        }
        public ImageView(string path)
        {
            InitializeComponent();
            
            try
            {
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                bitmap = new FastBitmap((Bitmap)Image.FromFile(path));
                pictureBox.Left = 0;
                pictureBox.Top = 0;
                ClientSize = bmp.Size;
                Text = Path.GetFileName(path);
                pictureBox.Image = bmp;

                this.path = path;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error creating bitmap!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
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

                this.path = "";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error creating bitmap!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        //public ImageView(string path, int id)
        //{
        //    InitializeComponent();


        //    StreamReader reader = new StreamReader(path);
        //    Bitmap bmpTemp = (Bitmap)Bitmap.FromStream(reader.BaseStream);
        //    Bitmap bmpTemp2 = new Bitmap(bmpTemp.Size.Width, bmpTemp.Size.Height);
        //    bmpTemp2.SetResolution(bmpTemp.HorizontalResolution, bmpTemp.VerticalResolution);
        //    Graphics gr = Graphics.FromImage(bmpTemp2);
        //    gr.DrawImage(bmpTemp, new Point());
        //    bmpTemp.Dispose();
        //    reader.Close();

        //    bitmap = new FastBitmap(bmpTemp2);
        //    bitmap.bitmap.SetResolution(96, 96);

        //    Text = Path.GetFileName(path);
        //    ClientSize = bitmap.Size;
        //    graphicsPanel.Left = 0;
        //    graphicsPanel.Top = 0;
        //    graphicsPanel.Size = bitmap.Size;

        //    graphics = this.graphicsPanel.CreateGraphics();

        //}

        public void Redraw()
        {
            //graphics.DrawImage(bmp, new Point());
            bitmap.Draw(graphics, 0, 0);
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            //Redraw();
        }

        public void setImage(Bitmap bmp)
        {
            pictureBox.Image = null;
            pictureBox.Image = bmp;
        }

        public void Save()
        {
            Save(path);
        }

        public void Save(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            ImageFormat format;
            switch (Path.GetExtension(filePath).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".tiff":
                    format = ImageFormat.Tiff;
                    break;
                default:
                    format = ImageFormat.Bmp;
                    break;
            }
            bitmap.Save(writer.BaseStream, format);
            writer.Close();
        }

        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (imageChanged)
            {
                switch (MessageBox.Show("Image \"" + Path.GetFileName(path) + "\" was changed. Save changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private static string GetHash(string input)
        {
            // Creates SHA256 Hash from input and adds random Int to make output unique
            Random rand = new Random();
            var sBuilder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input+rand.Next(0,100)));
                for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
