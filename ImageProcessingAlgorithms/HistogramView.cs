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
    public partial class HistogramView : Form
    {
        private Graphics graphics;
        private Histogram histogram;
        private Bitmap histogramImage;

        private Bitmap histogramImageRed;
        private Bitmap histogramImageGreen;
        private Bitmap histogramImageBlue;
        public HistogramView(Histogram histogram, string name)
        {
            InitializeComponent();
            Text = "Histogram of " + name;

            ClientSize = new Size(276, 276 + statusStrip1.Height); ;
            graphicsPanel.Size = new Size(256, 256);
            graphicsPanel.Left = 10;
            graphicsPanel.Top = 10;
            graphics = graphicsPanel.CreateGraphics();

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
                graphicsImage.DrawLine(Pens.Black, new Point(i, 255), new Point(i, 256 - (int)(256f * values[i])));
            }

            this.histogram = histogram;
        }
        public HistogramView(Histogram histogram, string name, bool gray)
        {
            InitializeComponent();
            Text = "Histogram of " + name;

            ClientSize = new Size(1000, 276 + statusStrip1.Height);
            //graphicsPanel.Size = new Size(256, 256);
            //graphicsPanel.Left = 10;
            //graphicsPanel.Top = 10;
            //graphics = graphicsPanel.CreateGraphics();

            redPanel.Size = new Size(256, 256);
            redPanel.Left = 100;
            redPanel.Top = 10;
            

            greenPanel.Size = new Size(256, 256);
            greenPanel.Left = 10;
            greenPanel.Top = 10;
            


            bluePanel.Size = new Size(256, 256);
            bluePanel.Left = 10;
            bluePanel.Top = 10;
            graphics = greenPanel.CreateGraphics();
            graphics = redPanel.CreateGraphics();
            graphics = bluePanel.CreateGraphics();

            float[] redValues = new float[256];
            float[] greenValues = new float[256];
            float[] blueValues = new float[256];
            for (int i = 0; i < 256; ++i)
            {
                redValues[i] = (float)histogram.HistogramTableRed[i] / histogram.Max;
                greenValues[i] = (float)histogram.HistogramTableGreen[i] / histogram.Max;
                blueValues[i] = (float)histogram.HistogramTableBlue[i] / histogram.Max;
            }

            histogramImageRed = new Bitmap(512, 256);
            histogramImageGreen = new Bitmap(512, 256);
            histogramImageBlue = new Bitmap(512, 256);
            Graphics graphicsImageRed = Graphics.FromImage(histogramImageRed);
            Graphics graphicsImageGreen = Graphics.FromImage(histogramImageGreen);
            Graphics graphicsImageBlue = Graphics.FromImage(histogramImageBlue);

            graphicsImageRed.Clear(Color.White);
            graphicsImageGreen.Clear(Color.White);
            graphicsImageBlue.Clear(Color.White);
            for (int i = 0; i < 256; ++i)
            {
                graphicsImageRed.DrawLine(Pens.Red, new Point(i, 255), new Point(i, 256 - (int)(256f * redValues[i])));
                graphicsImageGreen.DrawLine(Pens.Green, new Point(i, 255), new Point(i, 256 - (int)(256f * greenValues[i])));
                graphicsImageBlue.DrawLine(Pens.Blue, new Point(i, 255), new Point(i, 256 - (int)(256f * blueValues[i])));
            }
            this.histogram = histogram;
        }
        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawImage(histogramImage, new Point());
        }
        private void redPanel_Paint(object sender, PaintEventArgs e)
        {
            //graphics.DrawImage(histogramImageRed, new Point());
        }
        private void greenPanel_Paint(object sender, PaintEventArgs e)
        {
            //graphics.DrawImage(histogramImageGreen, new Point());
        }
        private void bluePanel_Paint(object sender, PaintEventArgs e)
        {
            //graphics.DrawImage(histogramImageBlue, new Point());
        }

        private void graphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = histogram.HistogramTable[e.X] + " pixels with a gray level of " + e.X.ToString();
        }
    }
}
