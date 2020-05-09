using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessingAlgorithms
{
    public partial class SharpenView : Form
    {
        // Variables
        public BorderType borderType = BorderType.Default;
        public Matrix<float> kernel = new Matrix<float>(new float[3,3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } });
        public SharpenView(string name)
        {
            // UI setup
            InitializeComponent();
            mask1Btn.Checked = true;
            isolatedBtn.Checked = true;
            Text = "Sharpen Configuration : " + name;
            ClientSize = new Size(300, 200);
            pictureBox1.Size = new Size(50, 50);
            pictureBox2.Size = new Size(50, 50);
            pictureBox3.Size = new Size(50, 50);

            pictureBox1.Top = 10;
            pictureBox1.Left = 10;
            pictureBox2.Top = 10;
            pictureBox2.Left = 125;
            pictureBox3.Top = 10;
            pictureBox3.Left = 240;

            mask1Btn.Top = 70;
            mask1Btn.Left = 10;
            mask2Btn.Top = 70;
            mask2Btn.Left = 125;
            mask3Btn.Top = 70;
            mask3Btn.Left = 240;

            label2.Top = 100;
            label2.Left = 10;

            buttonsLayout.Top = 115;
            buttonsLayout.Left = 10;

            applyBtn.Top = 150;
            applyBtn.Left = 110;
        }

        // Mask radio buttons
        private void mask1Btn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<float>(new float[3, 3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } });
        }

        private void mask2Btn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<float>(new float[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } });
        }

        private void mask3Btn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<float>(new float[3, 3] { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } });
        }

        // Border style radio buttons
        private void isolatedBtn_CheckedChanged(object sender, EventArgs e)
        {
            borderType = BorderType.Isolated;
        }

        private void reflectedBtn_CheckedChanged(object sender, EventArgs e)
        {
            borderType = BorderType.Reflect;
        }

        private void replicateBtn_CheckedChanged(object sender, EventArgs e)
        {
            borderType = BorderType.Replicate;
        }
    }
}
