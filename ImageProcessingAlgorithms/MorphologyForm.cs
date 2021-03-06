﻿using Emgu.CV.CvEnum;
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
    public partial class MorphologyView : Form
    {
        public ElementShape elementShape = ElementShape.Cross;
        public int iterations = 1;
        public MorphologyView(string name)
        {
            // UI setup
            InitializeComponent();
            CenterToScreen();
            crossRadio.Checked = true;
            Text = "Element Selection : " + name;
            label1.Text = "Iterations: " + trackBar1.Value;

            pictureBox1.Size = new Size(50, 50);
            pictureBox2.Size = new Size(50, 50);
        }

        private void crossRadio_CheckedChanged(object sender, EventArgs e)
        {
            // Getting kernel element type
            elementShape = ElementShape.Cross;
        }

        private void rectRadio_CheckedChanged(object sender, EventArgs e)
        {
            // Getting kernel element type
            elementShape = ElementShape.Rectangle;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Number of iterations
            iterations = trackBar1.Value;
            label1.Text = "Iterations: " + iterations;
        }
    }
}
