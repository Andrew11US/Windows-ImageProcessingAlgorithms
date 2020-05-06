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
            ClientSize = new Size(300, 250);
            label1.Size = new Size(280, 30);
            textBox1.Size = new Size(280, 100);

            label1.Top = 10;
            label1.Left = 80;
            textBox1.Top = 50;
            textBox1.Left = 10;

            doneBtn.Top = 160;
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

            /// Getting contour from std::vector
            VectorOfPoint cnt = contours[0];

            /// Contour area and perimeter
            area = CvInvoke.ContourArea(cnt);
            perimeter = CvInvoke.ArcLength(cnt, true);



            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("N: ").Append(m.M00);
            stringBuilder.Append("Area ").Append(area);
            stringBuilder.Append("per: ").Append(perimeter);

            textBox1.Text = stringBuilder.ToString();





  
           


            /*
            /// Getting contour from std::vector
            std::vector<cv::Point> cnt = contours[0];
            /// Contour area and perimeter
            area = contourArea(cnt);
            perimeter = arcLength(cnt, true);

            /// Calculation of aspect ratio
            cv::Rect rect = boundingRect(cnt);
            double aspectRatio = (double)(rect.width) / rect.height;

            /// Calculation of extent
            int rect_area = rect.width * rect.height;
            double extent = double(area) / rect_area;

            /// Calculation of solidity
            std::vector<cv::Point> hull;
            convexHull(cnt, hull);
            double hull_area = contourArea(hull);
            double solidity = double(area) / hull_area;

            /// Calculation of equivalent diameter
            double eq_diameter = sqrt(4 * area / M_PI);

            // Calculating dimensions
            for (int i = 0; i < gray.rows; ++i)
            {
                width = 0;
                for (int j = 0; j < gray.cols; ++j)
                {
                    width++;
                    totalPixels++;
                }
                height++;
            }

            // Calculating central point
            if (int(m.m00) != 0)
            {
                cX = int(m.m10 / m.m00);
                cY = int(m.m01 / m.m00);
            }

            // Adding data to metrics NSArray
            NSMutableArray* arr = [NSMutableArray arrayWithObjects:@(m.m00),@(m.m01),@(m.m10),@(m.m11),@(m.mu20),@(m.mu11),@(m.mu02),@(m.mu30), nil];
    [arr addObject:@(cX)];
    [arr addObject:@(cY)];
    [arr addObject:@(width)];
    [arr addObject:@(height)];
    [arr addObject:@(totalPixels)];
    [arr addObject:@(channels)];
    [arr addObject:@(area)];
    [arr addObject:@(perimeter)];
    [arr addObject:@(aspectRatio)];
    [arr addObject:@(extent)];
    [arr addObject:@(solidity)];
    [arr addObject:@(eq_diameter)];
    */
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
