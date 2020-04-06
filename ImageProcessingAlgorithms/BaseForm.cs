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
            EqualizeHistogram(EqualizationMethod.Averages);
        }

        // Action Functions
        private void EqualizeHistogram(EqualizationMethod method)
        {
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            Histogram histogram = ((ImageView)ActiveMdiChild).Histogram;
            ImageManager.EqualizeHistogram(bmp, histogram, method);
            Bitmap b = (Bitmap)bmp.bitmap.Clone();
            ((ImageView)ActiveMdiChild).setImage(b);
            ((ImageView)ActiveMdiChild).Refresh();
        }
        private void stretchHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //valueForm = new ValueForm(0, 255, "Enter the low value");
            //if (valueForm.ShowDialog() == DialogResult.OK)
            //{
            //    int low = valueForm.Value;
            //    valueForm = new ValueForm(0, 255, "Enter the high value");
            //    if (valueForm.ShowDialog() == DialogResult.OK)
            //    {
            //        ImageHelper.Rozciagnij(((ImageForm)ActiveMdiChild).Image, low, valueForm.Value);
            //        ((ImageForm)ActiveMdiChild).Refresh();
            //        ((ImageForm)ActiveMdiChild).Changed = true;
            //    }
            //}
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Stretch(bmp, 0, 255); // <== Tweaks needed!!!!!!!!!!!!!!!!!!!
            Bitmap b = (Bitmap)bmp.bitmap.Clone(); 
            ((ImageView)ActiveMdiChild).setImage(b);
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void negationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: refactor!!!
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Negation(bmp);
            Bitmap b = (Bitmap)bmp.bitmap.Clone(); 
            ((ImageView)ActiveMdiChild).setImage(b);
            ((ImageView)ActiveMdiChild).Refresh();
        }

        private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BitmapWrapper bmp = ((ImageView)ActiveMdiChild).image;
            ImageManager.Posterize(bmp, 4); // <== Change!!!!!!!!!!!!!!!!!!!!!!!!
            Bitmap b = (Bitmap)bmp.bitmap.Clone(); 
            ((ImageView)ActiveMdiChild).setImage(b);
            ((ImageView)ActiveMdiChild).Refresh();
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
    }
}
