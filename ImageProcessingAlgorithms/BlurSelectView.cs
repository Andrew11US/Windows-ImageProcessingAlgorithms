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
    public partial class BlurSelectView : Form
    {
        public int maskSize = 5;
        public BorderType borderType = BorderType.Default;
        public BlurSelectView(string name)
        {
            // UI setup
            InitializeComponent();
            isolatedBtn.Checked = true;
            Text = "Blur : " + name;
            ClientSize = new Size(300, 200);
            lblLayout.Size = new Size(280, 50);
            buttonsLayout.Size = new Size(280, 80);

            lblLayout.Top = 10;
            lblLayout.Left = 50;
            buttonsLayout.Top = 50;
            buttonsLayout.Left = 80;
            applyBtn.Top = 140;
            applyBtn.Left = 110;
            CenterToScreen();
        }

        private void maskSizeSelectorUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal value = maskSizeSelectorUpDown.Value;
            if (value <= 0)
            {
                maskSize = 1;
                maskSizeSelectorUpDown.Value = 1;
            }
            else if (value % 2 == 0)
            {
                maskSize = (int)(value - 1);
                maskSizeSelectorUpDown.Value = value - 1;
            }
            else if (value >= 500)
            {
                maskSize = 499;
                maskSizeSelectorUpDown.Value = 499;
            }
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
