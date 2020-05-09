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
    public partial class HistogramRGBView : Form
    {
        private Graphics graphicsRed;
        private Graphics graphicsGreen;
        private Graphics graphicsBlue;
        private Histogram histogram;

        private Bitmap histogramImageRed;
        private Bitmap histogramImageGreen;
        private Bitmap histogramImageBlue;
        public HistogramRGBView(Histogram histogram, string name)
        {
            // UI setup
            InitializeComponent();
            Text = "Histogram : " + name;
            toolStripStatusLabel1.Text = "Color Levels";

            ClientSize = new Size(788, 276 + statusStrip1.Height);
            flowLayout.Height = 276;
            redPanel.Size = new Size(256, 256);
            greenPanel.Size = new Size(256, 256);
            bluePanel.Size = new Size(256, 256);
            // Creating graphics for 3 channels
            graphicsRed = redPanel.CreateGraphics();
            graphicsGreen = greenPanel.CreateGraphics();
            graphicsBlue = bluePanel.CreateGraphics();
            // Storing values
            float[] redValues = new float[256];
            float[] greenValues = new float[256];
            float[] blueValues = new float[256];
            // Loop throgh histogram tables
            for (int i = 0; i < 256; ++i)
            {
                redValues[i] = (float)histogram.HistogramTableRed[i] / histogram.Max;
                greenValues[i] = (float)histogram.HistogramTableGreen[i] / histogram.Max;
                blueValues[i] = (float)histogram.HistogramTableBlue[i] / histogram.Max;
            }
            // Creating bitmaps for 3 channels
            histogramImageRed = new Bitmap(512, 256);
            histogramImageGreen = new Bitmap(512, 256);
            histogramImageBlue = new Bitmap(512, 256);
            // Initializing graphics objects
            Graphics graphicsImageRed = Graphics.FromImage(histogramImageRed);
            Graphics graphicsImageGreen = Graphics.FromImage(histogramImageGreen);
            Graphics graphicsImageBlue = Graphics.FromImage(histogramImageBlue);
            // Clearing
            graphicsImageRed.Clear(Color.White);
            graphicsImageGreen.Clear(Color.White);
            graphicsImageBlue.Clear(Color.White);
            // Drawing histograms
            for (int i = 0; i < 256; ++i)
            {
                graphicsImageRed.DrawLine(Pens.Red, new Point(i, 255), new Point(i, 256 - (int)(256f * redValues[i])));
                graphicsImageGreen.DrawLine(Pens.Green, new Point(i, 255), new Point(i, 256 - (int)(256f * greenValues[i])));
                graphicsImageBlue.DrawLine(Pens.Blue, new Point(i, 255), new Point(i, 256 - (int)(256f * blueValues[i])));
            }
            this.histogram = histogram;
        }
        private void redPanel_Paint(object sender, PaintEventArgs e)
        {
            // Show red
            graphicsRed.DrawImage(histogramImageRed, new Point());
        }
        private void greenPanel_Paint(object sender, PaintEventArgs e)
        {
            // Show green
            graphicsGreen.DrawImage(histogramImageGreen, new Point());
        }
        private void bluePanel_Paint(object sender, PaintEventArgs e)
        {
            // Show blue
            graphicsBlue.DrawImage(histogramImageBlue, new Point());
        }

        // Show luminosity levels for mouse hover
        private void redPanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = histogram.HistogramTableRed[e.X] + " pixels with a red level of " + e.X.ToString();
        }
        private void greenPanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = histogram.HistogramTableGreen[e.X] + " pixels with a green level of " + e.X.ToString();
        }
        private void bluePanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = histogram.HistogramTableBlue[e.X] + " pixels with a blue level of " + e.X.ToString();
        }
    }
}
