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
        ImageView imageForm;
        HistogramView histogramView;
        HistogramRGBView histogramRGBView;
        StretchView stretchView;
        ThresholdView thresholdView;
        PosterizeView posterizeView;

        // Additional variables
        private int childFormNumber = 0;

        public BaseForm()
        {
            InitializeComponent();
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
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //}
            try
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    imageForm = new ImageView(openFileDialog.FileName);
                    imageForm.MdiParent = this;
                    //imageForm.ChildID = childFormNumber++;
                    imageForm.Show();
                    //int ChildID = 0;

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

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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
    }
}
