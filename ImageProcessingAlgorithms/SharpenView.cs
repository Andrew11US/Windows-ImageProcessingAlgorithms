using Emgu.CV;
using Emgu.CV.CvEnum;
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
    public partial class SharpenView : Form
    {
        public BorderType borderType = BorderType.Default;
        public Matrix<float> kernel = new Matrix<float>(new float[3,3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } });
        public SharpenView(string name)
        {
            InitializeComponent();
            mask1Btn.Checked = true;
            Text = "Blur Configuration : " + name;
            ClientSize = new Size(300, 200);
            pictureBox1.Size = new Size(50, 50);
            pictureBox2.Size = new Size(50, 50);
            pictureBox3.Size = new Size(50, 50);

            pictureBox1.Top = 10;
            pictureBox1.Left = 10;
            pictureBox2.Top = 10;
            pictureBox2.Left = 60;
            pictureBox3.Top = 10;
            pictureBox3.Left = 110;
           
            applyBtn.Top = 140;
            applyBtn.Left = 110;
        }

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
