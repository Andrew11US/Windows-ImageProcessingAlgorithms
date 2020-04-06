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
        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawImage(histogramImage, new Point());
        }
        private void graphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = histogram.HistogramTable[e.X] + " pixels with a gray level of " + e.X.ToString();
        }
    }
}
