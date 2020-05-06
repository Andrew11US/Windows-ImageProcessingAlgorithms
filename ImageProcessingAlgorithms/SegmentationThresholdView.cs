using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingAlgorithms
{
    public partial class SegmentationThresholdView : Form
    {
        private Graphics graphics;
        private Bitmap histogramImage;
        public int thresholdValue = 128;
        private FastBitmap bitmap;
        public SegmentationThresholdView(Histogram histogram, string name, FastBitmap bmp)
        {
            InitializeComponent();
            bitmap = bmp;
            Text = "Threshold : " + name;
            previewPictureBox.Image = (Bitmap)bmp.bitmap.Clone();
            ClientSize = new Size(532, 700);
            histogramPanel.Size = new Size(512, 256);
            thresholdSlider.Size = new Size(532, 50);
            lblLayout.Size = new Size(512, 50);
            previewPictureBox.Size = new Size(512, 300);
            previewPictureBox.BackgroundImageLayout = ImageLayout.Center;

            histogramPanel.Left = 10;
            histogramPanel.Top = 10;
            thresholdSlider.Top = 266;
            thresholdSlider.Left = 0;
            lblLayout.Top = 296;
            lblLayout.Left = 10;
            applyBtn.Top = 640;
            applyBtn.Left = 230;

            previewPictureBox.Left = 10;
            previewPictureBox.Top = 326;

            graphics = histogramPanel.CreateGraphics();

            float[] values = new float[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (float)histogram.HistogramTable[i] / histogram.Max;
            }

            histogramImage = new Bitmap(512, 256);
            Graphics graphicsImage = Graphics.FromImage(histogramImage);

            graphicsImage.Clear(Color.White);
            for (int i = 0; i < 256; ++i)
            {
                graphicsImage.DrawLine(Pens.Black, new Point(i * 2, 255), new Point(i * 2, 256 - (int)(256f * values[i])));
            }
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            thresholdValue = thresholdSlider.Value;
            thresholdLbl.Text = thresholdValue.ToString();

            // Dynamic image set when scrollBar is changing
            FastBitmap temp = new FastBitmap((Bitmap)bitmap.bitmap.Clone());
            ImageManager.Threshold(temp, thresholdValue);
            previewPictureBox.Image = null;
            previewPictureBox.Image = (Bitmap)temp.bitmap.Clone();
        }
        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawImage(histogramImage, new Point());
        }
    }
}
