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
    public partial class PointOperationsView : Form
    {
        // Getters
        public string Operation => operationComboBox.Text;
        public string Image1 => image1ComboBox.Text;
        public string Image2 => image2ComboBox.Text;
        public PointOperationsView(string[] images)
        {
            // UI setup
            InitializeComponent();
            CenterToScreen();
            Text = "Point Operation";
            ClientSize = new Size(220, 220);
            image1ComboBox.Width = 200;
            image2ComboBox.Width = 200;
            operationComboBox.Width = 200;

            label1.Left = 10;
            label1.Top = 10;
            image1ComboBox.Left = 10;
            image1ComboBox.Top = 30;
            label2.Left = 10;
            label2.Top = 60;
            image2ComboBox.Top = 80;
            image2ComboBox.Left = 10;
            label3.Left = 10;
            label3.Top = 110;
            operationComboBox.Top = 130;
            operationComboBox.Left = 10;
            applyBtn.Top = 170;
            applyBtn.Left = 70;
            image1ComboBox.Items.AddRange(images);
            image2ComboBox.Items.AddRange(images);
            operationComboBox.Items.AddRange(Enum.GetNames(typeof(Operations)));

            operationComboBox.SelectedIndex = 0;
            if (images.Length == 1)
            {
                image1ComboBox.SelectedIndex = 0;
                image2ComboBox.SelectedIndex = 0;
            }
            else if (images.Length > 1)
            {
                image1ComboBox.SelectedIndex = 0;
                image2ComboBox.SelectedIndex = 1;
            }
        }
    }
}
