﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
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
/// Completed: 4 of 6
/// 
/// </summary>

namespace ImageProcessingAlgorithms
{
    public partial class BaseForm : Form
    {
        // Window Forms
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

        // Additional variables
        private int childFormNumber = 0;

        public BaseForm()
        {
            InitializeComponent();
            //ClientSize = new Size(1500, 1000);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Image files |*.jpg; *.jpeg; *.png; *.gif; *.tiff; *.bmp|All files (*.*)|*.*";

            try
            {
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void showHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Count() != 0)
            {
                showHistogramToolStripMenuItem.Enabled = true;
                histogramView = new HistogramView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);
                histogramView.MdiParent = this;
                histogramView.Show();
            }
            else
            {
                showHistogramToolStripMenuItem.Enabled = false;
            }

        }

        private void equalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.EqualizeHistogram(bmp, ((ImageView)ActiveMdiChild).Histogram, EqualizationMethod.Averages);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }
        private void stretchHistogramToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void showRGBHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Count() != 0)
            {
                showHistogramToolStripMenuItem.Enabled = true;
                histogramRGBView = new HistogramRGBView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);
                histogramRGBView.MdiParent = this;
                histogramRGBView.Show();
            }
            else
            {
                showHistogramToolStripMenuItem.Enabled = false;
            }
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Inversion(bmp);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void adjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.AdjustHistogram(bmp, ((ImageView)ActiveMdiChild).Histogram);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void thresholdGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            thresholdGrayscaleView = new ThresholdGrayscaleView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

            if (thresholdGrayscaleView.ShowDialog() == DialogResult.OK)
            {
                ImageManager.ThresholdGrayscale(bmp, thresholdGrayscaleView.lowerBound, thresholdGrayscaleView.upperBound);
                ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
                ((ImageView)ActiveMdiChild).Refresh();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
        }

        private void makeGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Grayscale(bmp);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void pointOperationsToolStripMenuItem_Click(object sender, EventArgs e)
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

                output = ImageManager.Operation(bmp1, bmp2, (Operations)Enum.Parse(typeof(Operations), pointOperationsView.Operation));
                ImageView imageView = new ImageView((Bitmap)output.bitmap.Clone());
                imageView.MdiParent = this;
                imageView.Show();
            }
        }

        private void medianFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            blurSelectView = new BlurSelectView(((ImageView)ActiveMdiChild).FileName);

            if (blurSelectView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = CvInvoke.Imread(path);
                dst = src.Clone();
                CvInvoke.MedianBlur(src, dst, blurSelectView.maskSize);
                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            blurSelectView = new BlurSelectView(((ImageView)ActiveMdiChild).FileName);

            if (blurSelectView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = CvInvoke.Imread(path);
                dst = src.Clone();
                CvInvoke.Blur(src, dst, new Size(blurSelectView.maskSize, blurSelectView.maskSize), new Point(-1, -1), blurSelectView.borderType);
                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            blurSelectView = new BlurSelectView(((ImageView)ActiveMdiChild).FileName);

            if (blurSelectView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = CvInvoke.Imread(path);
                dst = src.Clone();
                CvInvoke.GaussianBlur(src, dst, new Size(blurSelectView.maskSize, blurSelectView.maskSize), 0, 0, blurSelectView.borderType);
                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void sharpenMasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            sharpenView = new SharpenView(((ImageView)ActiveMdiChild).FileName);

            if (sharpenView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = CvInvoke.Imread(path);
                dst = src.Clone();
                CvInvoke.Filter2D(src, dst, sharpenView.kernel, new Point(-1, -1), 0, sharpenView.borderType);

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void customMask3x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            customMaskView = new CustomMaskView(((ImageView)ActiveMdiChild).FileName);

            if (customMaskView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = CvInvoke.Imread(path);
                dst = src.Clone();
                CvInvoke.Filter2D(src, dst, customMaskView.kernel, new Point(-1, -1), 0, customMaskView.borderType);

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            //BorderType borderType = BorderType.Default;
            Matrix<double> kernel = new Matrix<double>(new double[3, 3] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } });
            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();
            CvInvoke.Filter2D(src, dst, kernel, new Point(-1, -1), 0, BorderType.Isolated);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            //BorderType borderType = BorderType.Default;
            Matrix<double> kernel = new Matrix<double>(new double[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } });
            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();
            CvInvoke.Filter2D(src, dst, kernel, new Point(-1, -1), 0, BorderType.Isolated);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }

        private void directionDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            directionView = new DirectionView(((ImageView)ActiveMdiChild).FileName);

            if (directionView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                src = CvInvoke.Imread(path);
                dst = src.Clone();
                CvInvoke.Filter2D(src, dst, directionView.kernel, new Point(-1, -1), 0, directionView.borderType);

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void gxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();
            CvInvoke.Sobel(src, dst, src.Depth, 1, 0, 3);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }

        private void gyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();
            CvInvoke.Sobel(src, dst, src.Depth, 0, 1, 3);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();
            CvInvoke.Laplacian(src, dst, src.Depth, 1, 1, 0);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            cannyView = new CannyView(((ImageView)ActiveMdiChild).Histogram, ((ImageView)ActiveMdiChild).FileName);

            if (cannyView.ShowDialog() == DialogResult.OK)
            {
                string path = ((ImageView)ActiveMdiChild).path;
                Image<Bgr, byte> inputImage = new Image<Bgr, byte>(path);
                Image<Gray, byte> outputImage = new Image<Gray, byte>(path);
                outputImage = inputImage.Canny(cannyView.lowerBound, cannyView.upperBound);
                // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", outputImage);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)outputImage.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)outputImage.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void erodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

            if (morphologyView.ShowDialog() == DialogResult.OK)
            {
                string path = ((ImageView)ActiveMdiChild).path;
                Image<Bgr, byte> inputImage = new Image<Bgr, byte>(path);
                Image<Bgr, byte> outputImage = new Image<Bgr, byte>(path);

                // MARK: Creating custom kernel in order to get possibility to select morphological element
                Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                outputImage = inputImage.MorphologyEx(MorphOp.Erode, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", outputImage);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)outputImage.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)outputImage.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void dilateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

            if (morphologyView.ShowDialog() == DialogResult.OK)
            {
                string path = ((ImageView)ActiveMdiChild).path;
                Image<Bgr, byte> inputImage = new Image<Bgr, byte>(path);
                Image<Bgr, byte> outputImage = new Image<Bgr, byte>(path);

                // MARK: Creating custom kernel in order to get possibility to select morphological element
                Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                outputImage = inputImage.MorphologyEx(MorphOp.Dilate, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", outputImage);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)outputImage.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)outputImage.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

            if (morphologyView.ShowDialog() == DialogResult.OK)
            {
                string path = ((ImageView)ActiveMdiChild).path;
                Image<Bgr, byte> inputImage = new Image<Bgr, byte>(path);
                Image<Bgr, byte> outputImage = new Image<Bgr, byte>(path);

                // MARK: Creating custom kernel in order to get possibility to select morphological element
                Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                outputImage = inputImage.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", outputImage);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)outputImage.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)outputImage.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            morphologyView = new MorphologyView(((ImageView)ActiveMdiChild).FileName);

            if (morphologyView.ShowDialog() == DialogResult.OK)
            {
                string path = ((ImageView)ActiveMdiChild).path;
                Image<Bgr, byte> inputImage = new Image<Bgr, byte>(path);
                Image<Bgr, byte> outputImage = new Image<Bgr, byte>(path);

                // MARK: Creating custom kernel in order to get possibility to select morphological element
                Mat kernel = CvInvoke.GetStructuringElement(morphologyView.elementShape, new Size(3, 3), new Point(-1, -1));
                outputImage = inputImage.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), morphologyView.iterations, BorderType.Isolated, new MCvScalar(1, 0));

                // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object

                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", outputImage);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)outputImage.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)outputImage.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void twoStepFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;

            // MARK: EmguCV requires path because of inability to successfully convert Bitmap to Mat object
            string path = ((ImageView)ActiveMdiChild).path;
            doubleFiltrationView = new DoubleFiltrationView(((ImageView)ActiveMdiChild).FileName);

            if (doubleFiltrationView.ShowDialog() == DialogResult.OK)
            {
                Mat src = new Mat();
                Mat dst = new Mat();
                Mat tmp = new Mat();
                src = CvInvoke.Imread(path);
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
                
                // MARK: Uncomment following line to present image in native EmguCV Window
                //CvInvoke.Imshow("Output image", dst);

                // NOTE: Remove '/' at the beginning to present image in a new Window
                //       Add '/' to alter currently selected

                /*///
                ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
                ((ImageView)ActiveMdiChild).Refresh();
                /*/
                ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
                imageView.MdiParent = this;
                imageView.Show();
                //*///
            }
        }

        private void skeletonizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastBitmap bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Thinning(bmp);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void thresholdToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void adaptiveThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = ((ImageView)ActiveMdiChild).path;

            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();

            CvInvoke.CvtColor(src, src, ColorConversion.Bgra2Gray);
            CvInvoke.AdaptiveThreshold(src, dst, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, 0);
            CvInvoke.CvtColor(dst, dst, ColorConversion.Gray2Bgr);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///

        }

        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = ((ImageView)ActiveMdiChild).path;

            Mat src = new Mat();
            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();

            CvInvoke.CvtColor(src, src, ColorConversion.Bgra2Gray);
            CvInvoke.Threshold(src, dst, 127, 255, ThresholdType.Binary | ThresholdType.Otsu);
            CvInvoke.CvtColor(dst, dst, ColorConversion.Gray2Bgr);

            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)dst.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }

        private void watershedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = ((ImageView)ActiveMdiChild).path;

            Mat src;
            Mat gray = new Mat();
            Mat thresh = new Mat();
            Mat kernel = new Mat();
            Mat opening = new Mat();
            Mat item_bg = new Mat();
            Mat item_fg = new Mat();
            Mat dist_transform = new Mat();

            Mat dst = new Mat();
            src = CvInvoke.Imread(path);
            dst = src.Clone();

            CvInvoke.CvtColor(src, gray, ColorConversion.Bgra2Gray);
            CvInvoke.Threshold(gray, thresh, 0, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);
            kernel = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(3, 3), new Point(-1, -1));
            CvInvoke.MorphologyEx(thresh, opening, MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1, 0));
            CvInvoke.Dilate(opening, item_bg, kernel, new Point(-1, -1), 4, BorderType.Default, new MCvScalar(1, 0));

            CvInvoke.DistanceTransform(opening, dist_transform, null, DistType.L2, 5);

            CvInvoke.Threshold(dist_transform, item_fg, 0.5, 255, ThresholdType.Binary);
            CvInvoke.MorphologyEx(item_fg, item_fg, MorphOp.Erode, kernel, new Point(-1, -1), 10, BorderType.Default, new MCvScalar(1, 0));

            CvInvoke.CvtColor(item_fg, item_fg, ColorConversion.Gray2Bgr);


            //cv.distanceTransform(opening, distTrans, cv.DIST_L2, 5);
            //cv.normalize(distTrans, distTrans, 1, 0, cv.NORM_INF);

            //CvInvoke.MorphologyEx(thresh, opening, MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1, 0));

            //CvInvoke.CvtColor(dst, dst, ColorConversion.Gray2Bgr);



            // MARK: Uncomment following line to present image in native EmguCV Window
            //CvInvoke.Imshow("Output image", dst);

            // NOTE: Remove '/' at the beginning to present image in a new Window
            //       Add '/' to alter currently selected

            /*///
            ((ImageView)ActiveMdiChild).setImage((Bitmap)dst.ToBitmap().Clone());
            ((ImageView)ActiveMdiChild).Refresh();
            /*/
            ImageView imageView = new ImageView((Bitmap)item_fg.ToBitmap().Clone());
            imageView.MdiParent = this;
            imageView.Show();
            //*///
        }
    }
}
