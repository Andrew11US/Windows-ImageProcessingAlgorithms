using Emgu.CV;
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
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.EqualizeHistogram(bmp, ((ImageView)ActiveMdiChild).Histogram, EqualizationMethod.Averages);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }
        private void stretchHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
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
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
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
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
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
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Inversion(bmp);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void adjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.AdjustHistogram(bmp, ((ImageView)ActiveMdiChild).Histogram);
            ((ImageView)ActiveMdiChild).setImage((Bitmap)bmp.bitmap.Clone());
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void thresholdGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
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
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
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
                BitmapWrapper bmp1 = null;
                BitmapWrapper bmp2 = null;
                BitmapWrapper output;
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
    }
}
