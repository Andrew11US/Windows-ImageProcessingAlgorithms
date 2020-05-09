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
    public partial class ThresholdView : Form
    {
        // Variables
        private Graphics graphics;
        private Bitmap histogramImage;
        public int thresholdValue = 128;
        public ThresholdView(Histogram histogram, string name)
        {
            // UI setup
            InitializeComponent();
            Text = "Threshold : " + name;
            ClientSize = new Size(532, 380);
            histogramPanel.Size = new Size(512, 256);
            thresholdSlider.Size = new Size(532, 50);
            lblLayout.Size = new Size(512, 50);
            
            histogramPanel.Left = 10;
            histogramPanel.Top = 10;
            thresholdSlider.Top = 266;
            thresholdSlider.Left = 0;
            lblLayout.Top = 296;
            lblLayout.Left = 10;
            applyBtn.Top = 326;
            applyBtn.Left = 230;
  
            graphics = histogramPanel.CreateGraphics();
            // Creating histogram
            float[] values = new float[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (float)histogram.HistogramTable[i] / histogram.Max;
            }
            // creating bitmap
            histogramImage = new Bitmap(512, 256);
            Graphics graphicsImage = Graphics.FromImage(histogramImage);
            // drawing on bitmap
            graphicsImage.Clear(Color.White);
            for (int i = 0; i < 256; ++i)
            {
                graphicsImage.DrawLine(Pens.Black, new Point(i * 2, 255), new Point(i * 2, 256 - (int)(256f * values[i])));
            }
        }
        private void slider_Scroll(object sender, EventArgs e)
        {
            // getting threshold value
            thresholdValue = thresholdSlider.Value;
            thresholdLbl.Text = thresholdValue.ToString();
        }
        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            // drawing on panel
            graphics.DrawImage(histogramImage, new Point());
        }
    }
}
