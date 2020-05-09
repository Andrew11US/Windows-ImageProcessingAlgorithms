using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Author: Andrii Halabuda
/// Group: ID06IO2
/// Student ID: 17460
/// 
/// Completed: 6 of 6
/// 9 May 2020
/// 
/// GitHub repository: Andrew11US/Windows-ImageProcessingAlgorithms
/// 
/// </summary>

namespace ImageProcessingAlgorithms
{
    public partial class BaseForm : Form
    {
        // Adjustment Views
        ImageView imageView;
        HistogramView histogramView;
        HistogramRGBView histogramRGBView;
        StretchView stretchView;
        ThresholdView thresholdView;
        ThresholdGrayscaleView thresholdGrayscaleView;
        PosterizeView posterizeView;
        PointOperationsView pointOperationsView;
        BlurSelectView blurSelectView;
        SharpenView sharpenView;
        CustomMaskView customMaskView;
        DirectionView directionView;
        CannyView cannyView;
        MorphologyView morphologyView;
        DoubleFiltrationView doubleFiltrationView;
        SegmentationThresholdView segmentationThresholdView;
        MetricsView metricsView;
        ShapeDetectionView shapeDetectionView;
        AboutView aboutView;

        // Main constructor
        public BaseForm()
        {
            InitializeComponent();
            ClientSize = new Size(1200, 700);
            CenterToScreen();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            // Open File dialog to select an image for editing
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Types filter
            openFileDialog.Filter = "Image files |*.jpg; *.jpeg; *.png; *.gif; *.tiff; *.bmp|All files (*.*)|*.*";

            try
            {
                // Openning file dialog
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    imageView = new ImageView(openFileDialog.FileName);
                    imageView.MdiParent = this;
                    imageView.Show();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error opening file!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save action when imageView selected
            try
            {
                ((ImageView)ActiveMdiChild).Save();
            }
            catch
            {
                MessageBox.Show("Selected Item could not be saved!", "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close action
            Close();
        }

        // Window layout actions
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close inner window if axists
            if (ActiveMdiChild != null) ActiveMdiChild.Close();
            else MessageBox.Show("No window selected!", "Closing Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clone selected imageView
            if (ActiveMdiChild is ImageView)
            {
                ImageView duplicateView = new ImageView((Bitmap)((ImageView)ActiveMdiChild).bitmap.bitmap.Clone());
                duplicateView.MdiParent = this;
                duplicateView.Show();
            }
            else if (ActiveMdiChild is HistogramView)
            {
                MessageBox.Show("Unable to clone histogram. Image shold be selected!", "Clonning Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Nothing to clone!", "Clonning Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Loop through and close all child forms
            foreach (Form childForm in MdiChildren) childForm.Close();
        }

        private void showHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Histogram view setup
            if (ActiveMdiChild is ImageView)
            {
                showHistogramToolStripMenuItem.Enabled = true;
                histogramView = new HistogramView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);
                histogramView.MdiParent = this;
                histogramView.Show();
            }
            else
            {
                MessageBox.Show("Image shold be selected!","HistogramView Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void showRGBHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // RGB Histegram view setup
            if (ActiveMdiChild is ImageView)
            {
                showHistogramToolStripMenuItem.Enabled = true;
                histogramRGBView = new HistogramRGBView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);
                histogramRGBView.MdiParent = this;
                histogramRGBView.Show();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "RGB Histogram Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void equalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Image histogram equalization
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                ImageManager.EqualizeHistogram(bmp, ((ImageView)ActiveMdiChild).Histogram);
                ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Equalization Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void stretchHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Image histogram stretching
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                stretchView = new StretchView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

                if (stretchView.ShowDialog() == DialogResult.OK)
                {
                    ImageManager.Stretch(bmp, stretchView.lowerBound, stretchView.upperBound);
                    ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Stretching Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Posterization
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                posterizeView = new PosterizeView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

                if (posterizeView.ShowDialog() == DialogResult.OK)
                {
                    ImageManager.Posterize(bmp, posterizeView.grayLevels);
                    ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Posterization Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thresholding with binarization
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                thresholdView = new ThresholdView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

                if (thresholdView.ShowDialog() == DialogResult.OK)
                {
                    ImageManager.Threshold(bmp, thresholdView.thresholdValue);
                    ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Thresholding Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Image inverse
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                ImageManager.Inversion(bmp);
                ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Inversing Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void adjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Contrasting image
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                ImageManager.AdjustHistogram(bmp, ((ImageView)ActiveMdiChild).Histogram);
                ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Color Adjustment Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void thresholdGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thresholding with gray levels
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                thresholdGrayscaleView = new ThresholdGrayscaleView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

                if (thresholdGrayscaleView.ShowDialog() == DialogResult.OK)
                {
                    // Calling threshold
                    ImageManager.ThresholdGrayscale(bmp, thresholdGrayscaleView.lowerBound, thresholdGrayscaleView.upperBound);
                    ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Thresholding Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void makeGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Making grayscale
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                ImageManager.Grayscale(bmp);
                ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Grayscaling Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void pointOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Point operations
            if (MdiChildren.Count() > 0)
            {
                List<string> images = new List<string>();
                foreach (Form form in MdiChildren) images.Add(((ImageView)form).Text);
                pointOperationsView = new PointOperationsView(images.ToArray());

                if (pointOperationsView.ShowDialog() == DialogResult.OK)
                {
                    FastBitmap bmp1 = null;
                    FastBitmap bmp2 = null;
                    FastBitmap output;
                    foreach (Form form in MdiChildren)
                    {
                        if (((ImageView)form).Text == pointOperationsView.Image1)
                            bmp1 = ((ImageView)form).image;
                        if (((ImageView)form).Text == pointOperationsView.Image2)
                            bmp2 = ((ImageView)form).image;
                    }
                    // Performing selected operation and assigning result to new image view
                    output = ImageManager.Operation(bmp1, bmp2, (Operations)Enum.Parse(typeof(Operations), pointOperationsView.Operation));
                    ImageView imageView = new ImageView((Bitmap)output.bitmap.Clone());
                    imageView.MdiParent = this;
                    imageView.Show();
                }
            }
            else
            {
                MessageBox.Show("No images to process!", "Point operations Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void medianFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Median blur using EmguCV
            if (ActiveMdiChild is ImageView)
            {
                blurSelectView = new BlurSelectView(((ImageView)ActiveMdiChild).FileName);

                if (blurSelectView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    dst = src.Clone();
                    CvInvoke.MedianBlur(src, dst, blurSelectView.maskSize);

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Bluring Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Blur filter
            if (ActiveMdiChild is ImageView)
            {
                blurSelectView = new BlurSelectView(((ImageView)ActiveMdiChild).FileName);

                if (blurSelectView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    dst = src.Clone();
                    CvInvoke.Blur(src, dst, new Size(blurSelectView.maskSize, blurSelectView.maskSize), new Point(-1, -1), blurSelectView.borderType);

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Bluring Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gaussian bluring filter
            if (ActiveMdiChild is ImageView)
            {
                blurSelectView = new BlurSelectView(((ImageView)ActiveMdiChild).FileName);

                if (blurSelectView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    dst = src.Clone();
                    CvInvoke.GaussianBlur(src, dst, new Size(blurSelectView.maskSize, blurSelectView.maskSize), 0, 0, blurSelectView.borderType);

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Bluring Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void sharpenMasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sharpen filter
            if (ActiveMdiChild is ImageView)
            {
                sharpenView = new SharpenView(((ImageView)ActiveMdiChild).FileName);

                if (sharpenView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    dst = src.Clone();
                    CvInvoke.Filter2D(src, dst, sharpenView.kernel, new Point(-1, -1), 0, sharpenView.borderType);

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Sharpening Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void customMask3x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Custom mask 3x3
            if (ActiveMdiChild is ImageView)
            {
                customMaskView = new CustomMaskView(((ImageView)ActiveMdiChild).FileName);

                if (customMaskView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    dst = src.Clone();
                    CvInvoke.Filter2D(src, dst, customMaskView.kernel, new Point(-1, -1), 0, customMaskView.borderType);

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Vertical Prewitt operator
            if (ActiveMdiChild is ImageView)
            {
                Matrix<double> kernel = new Matrix<double>(new double[3, 3] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } });
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();
                CvInvoke.Filter2D(src, dst, kernel, new Point(-1, -1), 0, BorderType.Isolated);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Horizontal Prewitt operator
            if (ActiveMdiChild is ImageView)
            {
                Matrix<double> kernel = new Matrix<double>(new double[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } });
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();
                CvInvoke.Filter2D(src, dst, kernel, new Point(-1, -1), 0, BorderType.Isolated);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void directionDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Direction detection operators - 8 directions
            if (ActiveMdiChild is ImageView)
            {
                directionView = new DirectionView(((ImageView)ActiveMdiChild).FileName);

                if (directionView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    dst = src.Clone();
                    CvInvoke.Filter2D(src, dst, directionView.kernel, new Point(-1, -1), 0, directionView.borderType);

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sobel gx operator
            if (ActiveMdiChild is ImageView)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();
                CvInvoke.Sobel(src, dst, src.Depth, 1, 0, 3);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sobel gy operator
            if (ActiveMdiChild is ImageView)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();
                CvInvoke.Sobel(src, dst, src.Depth, 0, 1, 3);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Laplacian operator
            if (ActiveMdiChild is ImageView)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();
                CvInvoke.Laplacian(src, dst, src.Depth, 1, 1, 0);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Edge Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Canny edge operator
            if (ActiveMdiChild is ImageView)
            {
                cannyView = new CannyView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

                if (cannyView.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> inputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();
                    Image<Gray, byte> outputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Gray, byte>();
                    outputImage = inputImage.Canny(cannyView.lowerBound, cannyView.upperBound);

                    ((ImageView)ActiveMdiChild).setImage(outputImage.Mat);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Edge Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void erodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Morphology - erode
            if (ActiveMdiChild is ImageView)
            {
                morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

                if (morphologyView.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> inputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();
                    Image<Bgr, byte> outputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();

                    // MARK: Creating custom kernel in order to get possibility to select morphological element
                    Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                    outputImage = inputImage.MorphologyEx(MorphOp.Erode, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                    ((ImageView)ActiveMdiChild).setImage(outputImage.Mat);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Morphology Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dilateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Morphology - dilate
            if (ActiveMdiChild is ImageView)
            {
                morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

                if (morphologyView.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> inputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();
                    Image<Bgr, byte> outputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();

                    // MARK: Creating custom kernel in order to get possibility to select morphological element
                    Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                    outputImage = inputImage.MorphologyEx(MorphOp.Dilate, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                    ((ImageView)ActiveMdiChild).setImage(outputImage.Mat);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Morphology Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Morphology - Open
            if (ActiveMdiChild is ImageView)
            {
                morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

                if (morphologyView.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> inputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();
                    Image<Bgr, byte> outputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();

                    // MARK: Creating custom kernel in order to get possibility to select morphological element
                    Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                    outputImage = inputImage.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                    ((ImageView)ActiveMdiChild).setImage(outputImage.Mat);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Morphology Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Morphology - Close
            if (ActiveMdiChild is ImageView)
            {
                morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

                if (morphologyView.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> inputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();
                    Image<Bgr, byte> outputImage = ((ImageView)ActiveMdiChild).Mat.ToImage<Bgr, byte>();

                    // MARK: Creating custom kernel in order to get possibility to select morphological element
                    Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                    outputImage = inputImage.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                    ((ImageView)ActiveMdiChild).setImage(outputImage.Mat);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Morphology Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void twoStepFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Two step filtration 3x3 -> 5x5
            if (ActiveMdiChild is ImageView)
            {
                doubleFiltrationView = new DoubleFiltrationView(((ImageView)ActiveMdiChild).FileName);

                if (doubleFiltrationView.ShowDialog() == DialogResult.OK)
                {
                    Mat src = new Mat();
                    Mat dst = new Mat();
                    Mat tmp = new Mat();
                    src = ((ImageView)ActiveMdiChild).Mat;
                    tmp = src.Clone();
                    dst = src.Clone();
                    if (doubleFiltrationView.use5x5)
                    {
                        CvInvoke.Filter2D(src, dst, doubleFiltrationView.kernel, new Point(-1, -1), 0, doubleFiltrationView.borderType);
                    }
                    else
                    {
                        CvInvoke.Filter2D(src, tmp, doubleFiltrationView.first3x3, new Point(-1, -1), 0, doubleFiltrationView.borderType);
                        CvInvoke.Filter2D(tmp, dst, doubleFiltrationView.second3x3, new Point(-1, -1), 0, doubleFiltrationView.borderType);
                    }

                    ((ImageView)ActiveMdiChild).setImage(dst);
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void skeletonizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thinning image
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                ImageManager.Thinning(bmp);
                ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void thresholdToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Segmentation thresholding
            if (ActiveMdiChild is ImageView)
            {
                FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
                segmentationThresholdView = new SegmentationThresholdView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName, bmp);

                if (segmentationThresholdView.ShowDialog() == DialogResult.OK)
                {
                    ImageManager.Threshold(bmp, segmentationThresholdView.thresholdValue);
                    ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                    ((ImageView)ActiveMdiChild).Refresh();
                }
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Segmentation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void adaptiveThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Segmentation - adaptive thresholding
            if (ActiveMdiChild is ImageView)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();

                CvInvoke.CvtColor(src, src, ColorConversion.Bgra2Gray);
                CvInvoke.AdaptiveThreshold(src, dst, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, 0);
                CvInvoke.CvtColor(dst, dst, ColorConversion.Gray2Bgr);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Segmentation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Otsu thresholding
            if (ActiveMdiChild is ImageView)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = ((ImageView)ActiveMdiChild).Mat;
                dst = src.Clone();

                CvInvoke.CvtColor(src, src, ColorConversion.Bgra2Gray);
                CvInvoke.Threshold(src, dst, 127, 255, ThresholdType.Binary | ThresholdType.Otsu);
                CvInvoke.CvtColor(dst, dst, ColorConversion.Gray2Bgr);

                ((ImageView)ActiveMdiChild).setImage(dst);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Segmentation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void watershedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Segmentation - watershed
            if (ActiveMdiChild is ImageView)
            {
                Mat src = ((ImageView) ActiveMdiChild).Mat;
                Mat gray = new Mat();
                Mat thresh = new Mat();
                Mat kernel = new Mat();
                Mat opening = new Mat();
                Mat item_bg = new Mat();
                Mat item_fg = new Mat();
                Mat dist_transform = new Mat();
                Mat unknown = new Mat();
                Mat markers = new Mat();
                Mat dst = src.Clone();
                
                // Converting to Gray
                CvInvoke.CvtColor(src, gray, ColorConversion.Bgra2Gray);
                // Thresholding with Otsu
                CvInvoke.Threshold(gray, thresh, 0, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);
                // Morphology operations
                kernel = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(3, 3), new Point(-1, -1));
                CvInvoke.MorphologyEx(thresh, opening, MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1, 0));
                CvInvoke.Dilate(opening, item_bg, kernel, new Point(-1, -1), 4, BorderType.Default, new MCvScalar(1, 0));
                // Distance transformation
                CvInvoke.DistanceTransform(opening, dist_transform, null, DistType.L2, 5);
                // Enhancing visibility
                CvInvoke.Threshold(dist_transform, item_fg, 0.5, 255, ThresholdType.Binary);
                CvInvoke.MorphologyEx(item_fg, item_fg, MorphOp.Erode, kernel, new Point(-1, -1), 10, BorderType.Default, new MCvScalar(1, 0));

                item_fg.ConvertTo(item_fg, DepthType.Cv8U);
                // Subtraction foreground from background
                CvInvoke.Subtract(item_bg, item_fg, unknown);
                // Getting markers
                CvInvoke.ConnectedComponents(item_fg, markers);
                // Converting to appropriate types for watershed
                dst.ConvertTo(dst, DepthType.Cv8U);
                markers.ConvertTo(markers, DepthType.Cv32S);
                // Calling Watershed from cvInvoke
                CvInvoke.Watershed(dst, markers);
                // Converting dst to Image to perform subscription directly without pointers
                Image<Bgr, byte> outputImage = dst.ToImage<Bgr, byte>(false);

                // Draw distinct objects red
                for (int i = 0; i < markers.Rows; ++i)
                    for (int j = 0; j < markers.Cols; ++j)
                        outputImage.Data[i, j, 2] = 255;

                ((ImageView)ActiveMdiChild).setImage(outputImage.Mat);
                ((ImageView)ActiveMdiChild).Refresh();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Watershed Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void imageMetricsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show image metrics
            if (ActiveMdiChild is ImageView)
            {
                metricsView = new MetricsView(((ImageView)ActiveMdiChild), ((ImageView)ActiveMdiChild).FileName);
                metricsView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Image Metrics Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void shapeDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageView)
            {
                string shape;

                // Variables
                Image<Gray, byte> gray = ((ImageView)ActiveMdiChild).Mat.ToImage<Gray, byte>();
                Image<Gray, byte> thresh = ((ImageView)ActiveMdiChild).Mat.ToImage<Gray, byte>();
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

                // Smoothing and Thresholding
                gray = gray.SmoothGaussian(3);
                CvInvoke.Threshold(gray, thresh, 127, 255, ThresholdType.Binary);

                // Calling findContours from threshold
                CvInvoke.FindContours(gray, contours, new Mat(), RetrType.List, ChainApproxMethod.ChainApproxSimple);

                // Getting contour from vector
                VectorOfPoint cnt = contours[0];
                VectorOfPoint approx = new VectorOfPoint();

                CvInvoke.ApproxPolyDP(cnt, approx, 3, true);
                Rectangle rect = CvInvoke.BoundingRectangle(cnt);
                double aspectRatio = (double)(rect.Width) / rect.Height;

                // Detecting shape using approximation of polygon
                if (approx.Size == 3)
                {
                    shape = "triangle";
                }
                else if (approx.Size == 4)
                {
                    if (aspectRatio >= 0.95 && aspectRatio <= 1.05)
                    {
                        shape = "square";
                    }
                    else
                    {
                        shape = "rectangle";
                    }
                }
                else
                {
                    shape = "circle";
                }

                shapeDetectionView = new ShapeDetectionView(((ImageView)ActiveMdiChild).FileName, shape);
                shapeDetectionView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Image shold be selected!", "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show about the project info
            aboutView = new AboutView();
            aboutView.ShowDialog();
        }
    }
}
