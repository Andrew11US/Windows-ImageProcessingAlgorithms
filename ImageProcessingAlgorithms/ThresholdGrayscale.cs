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
    public partial class ThresholdGrayscaleView : Form
    {
        // Variables
        private Graphics graphics;
        private Bitmap histogramImage;
        public int lowerBound;
        public int upperBound;
        public ThresholdGrayscaleView(Histogram histogram, string name)
        {
            // UI setup
            InitializeComponent();
            Text = "Threshold without gray level reduction : " + name;
            ClientSize = new Size(532, 400);
            histogramPanel.Size = new Size(512, 256);
            trackBarLower.Size = new Size(532, 50);
            trackBarUpper.Size = new Size(532, 50);
            rowLayout.Size = new Size(512, 50);

            histogramPanel.Left = 10;
            histogramPanel.Top = 10;
            trackBarLower.Top = 266;
            trackBarLower.Left = 0;
            trackBarUpper.Top = 296;
            trackBarUpper.Left = 0;
            rowLayout.Top = 326;
            rowLayout.Left = 150;
            applyBtn.Top = 356;
            applyBtn.Left = 230;

            graphics = histogramPanel.CreateGraphics();
            // Creating historgam
            float[] values = new float[256];
            for (int i = 0; i < 256; ++i)
            {
                values[i] = (float)histogram.HistogramTable[i] / histogram.Max;
            }
            // Creating bitmap image
            histogramImage = new Bitmap(512, 256);
            Graphics graphicsImage = Graphics.FromImage(histogramImage);
            // histogrma drawing on image
            graphicsImage.Clear(Color.White);
            for (int i = 0; i < 256; ++i)
            {
                graphicsImage.DrawLine(Pens.Black, new Point(i * 2, 255), new Point(i * 2, 256 - (int)(256f * values[i])));
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e) { Close(); }
        private void trackBarLow_Scroll(object sender, EventArgs e)
        {
            // getting lower bound
            lowerBound = trackBarLower.Value;
            lowLbl.Text = lowerBound.ToString();
        }
        private void trackBarHigh_Scroll(object sender, EventArgs e)
        {
            // getting upper bound
            upperBound = trackBarUpper.Value;
            highLbl.Text = upperBound.ToString();
        }
        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            // draeing on panel
            graphics.DrawImage(histogramImage, new Point());
        }
    }
}
