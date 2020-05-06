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
    public partial class ShapeDetectionView : Form
    {
        public ShapeDetectionView(string name, string shape)
        {
            InitializeComponent();
            Text = "Shape Detection : " + name;

            ClientSize = new Size(300, 150);
            label1.Size = new Size(280, 30);
            label2.Size = new Size(280, 30);
            label3.Size = new Size(280, 30);

            label1.Top = 10;
            label1.Left = 70;
            label2.Top = 45;
            label2.Left = 50;
            label3.Top = 70;
            label3.Left = 50;

            doneBtn.Top = 100;
            doneBtn.Left = 110;
            doneBtn.Focus();

            label2.Text = "Detected shape is " + shape;
            label3.Text = "Using EmguCV approximation";
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
