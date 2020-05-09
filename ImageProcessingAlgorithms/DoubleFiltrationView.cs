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
    public partial class DoubleFiltrationView : Form
    {
        // Variables
        private double divisor1 = 1;
        private double divisor2 = 1;
        private double divisor3 = 1;
        public bool use5x5 = false;
        public BorderType borderType = BorderType.Default;
        public Matrix<double> first3x3 = new Matrix<double>(new double[3, 3]);
        public Matrix<double> second3x3 = new Matrix<double>(new double[3, 3]);
        public Matrix<double> kernel = new Matrix<double>(new double[5, 5]);
        public DoubleFiltrationView(string name)
        {
            // UI setup
            InitializeComponent();
            isolatedBtn.Checked = true;
            Text = "Double Filtration : " + name;
            CalculateFirst3x3();
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void CalculateFirst3x3()
        {
            // Calculating first matrix
            first3x3[0, 0] = ParseInt(mask1Box.Text);
            first3x3[0, 1] = ParseInt(mask2Box.Text);
            first3x3[0, 2] = ParseInt(mask3Box.Text);
            first3x3[1, 0] = ParseInt(mask4Box.Text);
            first3x3[1, 1] = ParseInt(mask5Box.Text);
            first3x3[1, 2] = ParseInt(mask6Box.Text);
            first3x3[2, 0] = ParseInt(mask7Box.Text);
            first3x3[2, 1] = ParseInt(mask8Box.Text);
            first3x3[2, 2] = ParseInt(mask9Box.Text);

            if (!autoCheckBox1.Checked) divisor2 = Math.Max(ParseInt(divisorBox1.Text), 1);
            else
            {
                divisor1 = 0;
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        divisor1 += first3x3[i, j];

                divisor1 = Math.Max(divisor1, 1);

                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        first3x3[i, j] = first3x3[i, j] / divisor1;

                divisorBox1.Text = ((int)divisor1).ToString();
            }
        }

        private void CalculateSecond3x3()
        {
            // Calculating second matrix
            second3x3[0, 0] = ParseInt(mask2_1Box.Text);
            second3x3[0, 1] = ParseInt(mask2_2Box.Text);
            second3x3[0, 2] = ParseInt(mask2_3Box.Text);
            second3x3[1, 0] = ParseInt(mask2_4Box.Text);
            second3x3[1, 1] = ParseInt(mask2_5Box.Text);
            second3x3[1, 2] = ParseInt(mask2_6Box.Text);
            second3x3[2, 0] = ParseInt(mask2_7Box.Text);
            second3x3[2, 1] = ParseInt(mask2_8Box.Text);
            second3x3[2, 2] = ParseInt(mask2_9Box.Text);

            if (!autoCheckBox2.Checked) divisor2 = Math.Max(ParseInt(divisorBox2.Text), 1);
            else
            {
                divisor2 = 0;
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        divisor2 += second3x3[i, j];

                divisor2 = Math.Max(divisor2, 1);

                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        second3x3[i, j] = second3x3[i, j] / divisor2;

                divisorBox2.Text = ((int)divisor2).ToString();
            }
        }

        private void CalculateKernel()
        {
            // Calculating kernel from 3x3 matrix combination
            Matrix<double> temp = new Matrix<double>(new double[5, 5]);
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    kernel[i, j] = 0;
                    for (int k = -1; k < 2; ++k)
                    {
                        for (int l = -1; l < 2; ++l)
                        {
                            if (i + k - 1 >= 0 && i + k - 1 < 3 && j + l - 1 >= 0 && j + l - 1 < 3)
                            {
                                kernel[i, j] += first3x3[i + k - 1, j + l - 1] * second3x3[1 + k, 1 + l];
                                temp[i, j] = Math.Round(first3x3[i + k - 1, j + l - 1] * second3x3[1 + k, 1 + l], 2);
                            }
                                
                        }
                    }
                }
            }

            mask3_0_0Box.Text = temp[0, 0].ToString();
            mask3_0_1Box.Text = temp[0, 1].ToString();
            mask3_0_2Box.Text = temp[0, 2].ToString();
            mask3_0_3Box.Text = temp[0, 3].ToString();
            mask3_0_4Box.Text = temp[0, 4].ToString();

            mask3_1_0Box.Text = temp[1, 0].ToString();
            mask3_1_1Box.Text = temp[1, 1].ToString();
            mask3_1_2Box.Text = temp[1, 2].ToString();
            mask3_1_3Box.Text = temp[1, 3].ToString();
            mask3_1_4Box.Text = temp[1, 4].ToString();

            mask3_2_0Box.Text = temp[2, 0].ToString();
            mask3_2_1Box.Text = temp[2, 1].ToString();
            mask3_2_2Box.Text = temp[2, 2].ToString();
            mask3_2_3Box.Text = temp[2, 3].ToString();
            mask3_2_4Box.Text = temp[2, 4].ToString();

            mask3_3_0Box.Text = temp[3, 0].ToString();
            mask3_3_1Box.Text = temp[3, 1].ToString();
            mask3_3_2Box.Text = temp[3, 2].ToString();
            mask3_3_3Box.Text = temp[3, 3].ToString();
            mask3_3_4Box.Text = temp[3, 4].ToString();

            mask3_4_0Box.Text = temp[4, 0].ToString();
            mask3_4_1Box.Text = temp[4, 1].ToString();
            mask3_4_2Box.Text = temp[4, 2].ToString();
            mask3_4_3Box.Text = temp[4, 3].ToString();
            mask3_4_4Box.Text = temp[4, 4].ToString();

            divisor3 = divisor1 * divisor2;
            kernelDivisorLbl.Text = divisor3.ToString();
        }

        // Parse Int from String
        private int ParseInt(string s)
        {
            try { return int.Parse(s); }
            catch { return 0; }
        }

        private void autoCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Autodivisor setup
            if (autoCheckBox1.Checked == false) divisorBox1.Enabled = true;
            else divisorBox1.Enabled = false;
            CalculateFirst3x3();
        }

        private void autoCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Autodivisor setup
            if (autoCheckBox2.Checked == false) divisorBox2.Enabled = true;
            else divisorBox1.Enabled = false;
            CalculateSecond3x3();
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

        // Apply button action
        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateFirst3x3();
                CalculateSecond3x3();
                CalculateKernel();
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            use5x5 = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            use5x5 = true;
        }

        private void divisorBox1_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
        }

        private void divisorBox2_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
        }

        private void mask1Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask2Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask3Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask4Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask5Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask6Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask7Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask8Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask9Box_TextChanged(object sender, EventArgs e)
        {
            CalculateFirst3x3();
            CalculateKernel();
        }

        private void mask2_1Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_2Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_3Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_4Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_5Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_6Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_7Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_8Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }

        private void mask2_9Box_TextChanged(object sender, EventArgs e)
        {
            CalculateSecond3x3();
            CalculateKernel();
        }
    }
}
