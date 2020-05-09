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
    public partial class CustomMaskView : Form
    {
        private double divisor = 1;
        public BorderType borderType = BorderType.Default;
        public Matrix<double> kernel = new Matrix<double>(new double[3, 3] 
        { 
            { 1, 1, 1 }, 
            { 1, 1, 1 }, 
            { 1, 1, 1 } 
        });
        public CustomMaskView(string name)
        {
            InitializeComponent();
            CenterToScreen();
            isolatedBtn.Checked = true;
            Text = "Custom mask : " + name;
            ClientSize = new Size(300, 200);
            matrixLayout.Size = new Size(120, 100);
            buttonsLayout.Size = new Size(100, 80);

            matrixLayout.Top = 10;
            matrixLayout.Left = 10;
            label1.Top = 100;
            label1.Left = 10;
            divisorLayout.Top = 115;
            divisorLayout.Left = 10;
            label2.Top = 10;
            label2.Left = 130;
            buttonsLayout.Top = 30;
            buttonsLayout.Left = 130;

            applyBtn.Top = 145;
            applyBtn.Left = 110;
            Calculate();
        }

        private void Calculate()
        {
            kernel[0, 0] = ParseInt(mask1Box.Text);
            kernel[0, 1] = ParseInt(mask2Box.Text);
            kernel[0, 2] = ParseInt(mask3Box.Text);
            kernel[1, 0] = ParseInt(mask4Box.Text);
            kernel[1, 1] = ParseInt(mask5Box.Text);
            kernel[1, 2] = ParseInt(mask6Box.Text);
            kernel[2, 0] = ParseInt(mask7Box.Text);
            kernel[2, 1] = ParseInt(mask8Box.Text);
            kernel[2, 2] = ParseInt(mask9Box.Text);

            if (!autoCheckBox.Checked) divisor = Math.Max(ParseInt(divisorBox.Text), 1);
            else
            {
                divisor = 0;
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        divisor += kernel[i, j];

                divisor = Math.Max(divisor, 1);

                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        kernel[i, j] = kernel[i, j] / divisor;

                divisorBox.Text = ((int)divisor).ToString();
            }
        }

        private int ParseInt(string s)
        {
            try { return int.Parse(s); }
            catch { return 0; }
        }

        private void divisorBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void autoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoCheckBox.Checked == false) divisorBox.Enabled = true;
            else divisorBox.Enabled = false;
            Calculate();
        }

        private void mask1Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            //mask1Box.Text = (string)ParseInt(mask1Box.Text).ToString();
        }

        private void mask2Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask3Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask4Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask5Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask6Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask7Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask8Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void mask9Box_TextChanged(object sender, EventArgs e)
        {
            Calculate();
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

        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
