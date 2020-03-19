using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingAlgorithms
{
    public partial class ImageForm : Form
    {
        // Variables declarations
        public string path;
        public BitmapWrapper bitmap;
        public bool imageChanged = false;
        public int ChildID { get; set; }
        public string FileName
        {
            get { return Path.GetFileName(path); }
        }
        public Histogram Histogram
        {
            get { return new Histogram(bitmap); }
        }

        public ImageForm()
        {
            InitializeComponent();
        }
        public ImageForm(string path)
        {
            InitializeComponent();
            
            try
            {
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                pictureBox.Left = 0;
                pictureBox.Top = 0;
                ClientSize = bmp.Size;
                Text = Path.GetFileName(path+ChildID);
                pictureBox.Image = bmp;

                this.path = path;
                bitmap = new BitmapWrapper(bmp);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error creating bitmap!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
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
    }
}
