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
            InitializeComponent();
            Text = "Blur Configuration : " + name;
            ClientSize = new Size(532, 380);
            //histogramPanel.Size = new Size(512, 256);
            //thresholdSlider.Size = new Size(532, 50);
            //lblLayout.Size = new Size(512, 50);

            //histogramPanel.Left = 10;
            //histogramPanel.Top = 10;
            //thresholdSlider.Top = 266;
            //thresholdSlider.Left = 0;
            //lblLayout.Top = 296;
            //lblLayout.Left = 10;
            //applyBtn.Top = 326;
            //applyBtn.Left = 230;
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
