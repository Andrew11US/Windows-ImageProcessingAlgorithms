using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
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
    public partial class MetricsView : Form
    {
        private string path;
        public MetricsView(FastBitmap bmp, string path, string name)
        {
            InitializeComponent();
            Text = "Image Metrics : " + name;
            this.path = path;
            ClientSize = new Size(300, 600);
            label1.Size = new Size(280, 30);
            textBox1.Size = new Size(280, 490);

            label1.Top = 10;
            label1.Left = 80;
            textBox1.Top = 50;
            textBox1.Left = 10;

            doneBtn.Top = 550;
            doneBtn.Left = 110;
            doneBtn.Focus();

            ShowMetrics(bmp);
        }

        private void ShowMetrics(FastBitmap bmp)
        {
            Mat src = new Mat();
            Image<Gray, byte> gray = new Image<Gray, byte>(path);
            Mat thresh = new Mat();
            Mat cannyOutput = new Mat();
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();

            src = CvInvoke.Imread(path);

            /// Central points
            int cX = 0, cY = 0;
            /// Image dimensions
            int totalPixels = 0, width = 0, height = 0;
            double area = 0, perimeter = 0;

            CvInvoke.CvtColor(src, gray, ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(gray, thresh, 127, 255, ThresholdType.Binary);

            /// Getting moments
            Moments m = CvInvoke.Moments(thresh, true);

            CvInvoke.Blur(gray, gray, new Size(3, 3), new Point(-1, -1));
            gray = gray.Canny(50, 100);
            ///// Calling findContours from canny threshold
            CvInvoke.FindContours(gray, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);

            /// Getting contour from contours
            VectorOfPoint cnt = contours[0];

            /// Contour area and perimeter
            area = CvInvoke.ContourArea(cnt);
            perimeter = CvInvoke.ArcLength(cnt, true);
            
            /// Calculation of aspect ratio
            Rectangle rect = CvInvoke.BoundingRectangle(cnt);
            double aspectRatio = (double)(rect.Width) / rect.Height;

            /// Calculation of extent
            int rect_area = rect.Width * rect.Height;
            double extent = area / rect_area;

            /// Calculation of solidity
            VectorOfPoint hull = new VectorOfPoint();
            CvInvoke.ConvexHull(cnt, hull);
            double hull_area = CvInvoke.ContourArea(hull);
            double solidity = area / hull_area;

            /// Calculation of equivalent diameter
            double eq_diameter = Math.Sqrt(4 * area / Math.PI);

            // Calculating dimensions
            for (int i = 0; i < gray.Rows; ++i)
            {
                width = 0;
                for (int j = 0; j < gray.Cols; ++j)
                {
                    width++;
                    totalPixels++;
                }
                height++;
            }

            // Calculating central point
            if (Convert.ToInt32(m.M00) != 0)
            {
                cX = Convert.ToInt32(m.M10 / m.M00);
                cY = Convert.ToInt32(m.M01 / m.M00);
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.
                Append("Image Dimensions").Append(Environment.NewLine)
                .Append("Width: ").Append(width).Append(Environment.NewLine)
                .Append("Height: ").Append(height).Append(Environment.NewLine)
                .Append("Total pixels: ").Append(totalPixels).Append(Environment.NewLine)
                .Append("Megapixels: ").Append((double)(totalPixels) / 1000000).Append(" MPs").Append(Environment.NewLine)
                .Append("Channels: ").Append(gray.NumberOfChannels).Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Moments").Append(Environment.NewLine)
                .Append("Moment m(0,0): ").Append(m.M00).Append(Environment.NewLine)
                .Append("Moment m(0,1): ").Append(m.M01).Append(Environment.NewLine)
                .Append("Moment m(1,0): ").Append(m.M10).Append(Environment.NewLine)
                .Append("Moment m(1,1): ").Append(m.M11).Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Central Moments").Append(Environment.NewLine)
                .Append("Central Moment mu(20): ").Append(m.Mu20).Append(Environment.NewLine)
                .Append("Central Moment mu(11): ").Append(m.Mu11).Append(Environment.NewLine)
                .Append("Central Moment mu(02): ").Append(m.Mu02).Append(Environment.NewLine)
                .Append("Central Moment mu(30): ").Append(m.Mu30).Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Center of mass").Append(Environment.NewLine)
                .Append("Central Point: ").Append("(").Append(cX).Append(", ").Append(cY).Append(")").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Object Properties").Append(Environment.NewLine)
                .Append("Area: ").Append(Convert.ToInt32(area)).Append(Environment.NewLine)
                .Append("Perimeter: ").Append(Convert.ToInt32(perimeter)).Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Contour Properties").Append(Environment.NewLine)
                .Append("Aspect Ratio: 1 : ").Append(aspectRatio).Append(Environment.NewLine)
                .Append("Extent: ").Append(extent).Append(Environment.NewLine)
                .Append("Solidity: ").Append(solidity).Append(Environment.NewLine)
                .Append("Equivalent Diameter: ").Append(eq_diameter).Append(Environment.NewLine);

            textBox1.Text = stringBuilder.ToString();
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
