﻿using System;
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
    public partial class CannyView : Form
    {
        private Graphics graphics;
        private Bitmap histogramImage;
        public int lowerBound;
        public int upperBound;
        public CannyView(Histogram histogram, string name)
        {
            // UI setup
            InitializeComponent();
            CenterToScreen();
            Text = "Canny : " + name;
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
            applyBtn.Left = 220;
            graphics = histogramPanel.CreateGraphics();
            // Creating histogram
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
        private void trackBarLow_Scroll(object sender, EventArgs e)
        {
            // Getting bounds - lower
            lowerBound = trackBarLower.Value;
            lowLbl.Text = lowerBound.ToString();
        }
        private void trackBarHigh_Scroll(object sender, EventArgs e)
        {
            // Getting bounds - upper
            upperBound = trackBarUpper.Value;
            highLbl.Text = upperBound.ToString();
        }
        private void histogramPanel_Paint(object sender, PaintEventArgs e)
        {
            // drawing on panel
            graphics.DrawImage(histogramImage, new Point());
        }
    }
}
