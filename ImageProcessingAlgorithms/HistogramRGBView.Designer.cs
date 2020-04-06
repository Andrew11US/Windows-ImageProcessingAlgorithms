namespace ImageProcessingAlgorithms
{
    partial class HistogramRGBView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.redPanel = new System.Windows.Forms.Panel();
            this.greenPanel = new System.Windows.Forms.Panel();
            this.bluePanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1.SuspendLayout();
            this.flowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // redPanel
            // 
            this.redPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.redPanel.Location = new System.Drawing.Point(3, 3);
            this.redPanel.Name = "redPanel";
            this.redPanel.Size = new System.Drawing.Size(256, 256);
            this.redPanel.TabIndex = 0;
            this.redPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.redPanel_Paint);
            this.redPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.redPanel_MouseMove);
            // 
            // greenPanel
            // 
            this.greenPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.greenPanel.Location = new System.Drawing.Point(265, 3);
            this.greenPanel.Name = "greenPanel";
            this.greenPanel.Size = new System.Drawing.Size(256, 256);
            this.greenPanel.TabIndex = 1;
            this.greenPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.greenPanel_Paint);
            this.greenPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.greenPanel_MouseMove);
            // 
            // bluePanel
            // 
            this.bluePanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.bluePanel.Location = new System.Drawing.Point(527, 3);
            this.bluePanel.Name = "bluePanel";
            this.bluePanel.Size = new System.Drawing.Size(256, 256);
            this.bluePanel.TabIndex = 2;
            this.bluePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bluePanel_Paint);
            this.bluePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bluePanel_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 366);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1454, 39);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(206, 30);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // flowLayout
            // 
            this.flowLayout.Controls.Add(this.redPanel);
            this.flowLayout.Controls.Add(this.greenPanel);
            this.flowLayout.Controls.Add(this.bluePanel);
            this.flowLayout.Location = new System.Drawing.Point(12, 12);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(1430, 351);
            this.flowLayout.TabIndex = 3;
            // 
            // HistogramRGBView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 405);
            this.Controls.Add(this.flowLayout);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HistogramRGBView";
            this.Text = "HistogramRGBView";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel redPanel;
        private System.Windows.Forms.Panel greenPanel;
        private System.Windows.Forms.Panel bluePanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
    }
}