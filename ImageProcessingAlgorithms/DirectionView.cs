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
    public partial class DirectionView : Form
    {
        public BorderType borderType = BorderType.Default;
        public Matrix<double> kernel = new Matrix<double>(new double[3, 3] { 
            { 1, 1, 1 },
            { 0, 1, 0 },
            { -1, -1, -1 } 
        });
        public DirectionView(string name)
        {
            InitializeComponent();
            nBtn.Checked = true;
            isolatedBtn.Checked = true;
            Text = "Direction Detection : " + name;
            ClientSize = new Size(390, 220);
            directionsLayout.Size = new Size(370,80);
            buttonsLayout.Size = new Size(300, 50);
            wLayout.Size = new Size(100, 70);
            cLayout.Size = new Size(150, 70);
            eLayout.Size = new Size(100, 70);

            directionsLayout.Top = 10;
            directionsLayout.Left = 10;
            borderLayout.Top = 100;
            borderLayout.Left = 10;
            applyBtn.Top = 160;
            applyBtn.Left = 150;
        }

        private void nwBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] { 
                { 1, 1, 0 }, 
                { 1, 1, -1 }, 
                { 0, -1, -1 } 
            });
    }

        private void nBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { 1, 1, 1 },
                { 0, 1, 0 },
                { -1, -1, -1 }
            });
        }

        private void neBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { 0, 1, 1 },
                { -1, 1, 1 },
                { -1, -1, 0 }
            });
        }

        private void wBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { 1, 0, -1 },
                { 1, 1, -1 },
                { 1, 0, -1 }
            });
        }

        private void eBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { -1, 0, 1 }, 
                {- 1, 1, 1 }, 
                { -1, 0, 1 }
            });
        }

        private void swBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { 0, -1, -1 },
                { 1, 1, -1 },
                { 1, 1, 0 }
            });
        }

        private void sBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { -1, -1, -1 },
                { 0, 1, 0 },
                { 1, 1, 1 }
            });
        }

        private void seBtn_CheckedChanged(object sender, EventArgs e)
        {
            kernel = new Matrix<double>(new double[3, 3] {
                { -1, -1, 0 },
                { -1, 1, 1 },
                { 0, 1, 1 }
            });
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
