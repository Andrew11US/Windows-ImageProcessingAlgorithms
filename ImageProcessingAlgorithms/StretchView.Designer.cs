namespace ImageProcessingAlgorithms
{
    partial class StretchView
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
            this.trackBarLower = new System.Windows.Forms.TrackBar();
            this.trackBarUpper = new System.Windows.Forms.TrackBar();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lowLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.highLbl = new System.Windows.Forms.Label();
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.rowLayout.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarLower
            // 
            this.trackBarLower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarLower.Location = new System.Drawing.Point(12, 185);
            this.trackBarLower.Maximum = 255;
            this.trackBarLower.Name = "trackBarLower";
            this.trackBarLower.Size = new System.Drawing.Size(1108, 80);
            this.trackBarLower.TabIndex = 2;
            this.trackBarLower.Scroll += new System.EventHandler(this.trackBarLow_Scroll);
            // 
            // trackBarUpper
            // 
            this.trackBarUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarUpper.Location = new System.Drawing.Point(15, 237);
            this.trackBarUpper.Maximum = 255;
            this.trackBarUpper.Name = "trackBarUpper";
            this.trackBarUpper.Size = new System.Drawing.Size(1095, 80);
            this.trackBarUpper.TabIndex = 3;
            this.trackBarUpper.Value = 255;
            this.trackBarUpper.Scroll += new System.EventHandler(this.trackBarHigh_Scroll);
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(263, 3);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(166, 61);
            this.applyBtn.TabIndex = 4;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(435, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(166, 61);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lower:";
            // 
            // lowLbl
            // 
            this.lowLbl.AutoSize = true;
            this.lowLbl.Location = new System.Drawing.Point(115, 0);
            this.lowLbl.Name = "lowLbl";
            this.lowLbl.Size = new System.Drawing.Size(32, 32);
            this.lowLbl.TabIndex = 8;
            this.lowLbl.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Upper:";
            // 
            // highLbl
            // 
            this.highLbl.AutoSize = true;
            this.highLbl.Location = new System.Drawing.Point(265, 0);
            this.highLbl.Name = "highLbl";
            this.highLbl.Size = new System.Drawing.Size(66, 32);
            this.highLbl.TabIndex = 10;
            this.highLbl.Text = "255";
            // 
            // histogramPanel
            // 
            this.histogramPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.histogramPanel.Location = new System.Drawing.Point(15, 12);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(1095, 167);
            this.histogramPanel.TabIndex = 11;
            this.histogramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPanel_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 661);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1132, 39);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(206, 30);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // rowLayout
            // 
            this.rowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowLayout.Controls.Add(this.label1);
            this.rowLayout.Controls.Add(this.lowLbl);
            this.rowLayout.Controls.Add(this.label3);
            this.rowLayout.Controls.Add(this.highLbl);
            this.rowLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowLayout.Location = new System.Drawing.Point(15, 301);
            this.rowLayout.Name = "rowLayout";
            this.rowLayout.Size = new System.Drawing.Size(1095, 58);
            this.rowLayout.TabIndex = 13;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsPanel.Controls.Add(this.applyBtn);
            this.buttonsPanel.Controls.Add(this.cancelBtn);
            this.buttonsPanel.Location = new System.Drawing.Point(12, 400);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(260, 0, 0, 30);
            this.buttonsPanel.Size = new System.Drawing.Size(1108, 100);
            this.buttonsPanel.TabIndex = 14;
            // 
            // StretchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 700);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.rowLayout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.histogramPanel);
            this.Controls.Add(this.trackBarUpper);
            this.Controls.Add(this.trackBarLower);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StretchView";
            this.Text = "StretchView";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.rowLayout.ResumeLayout(false);
            this.rowLayout.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBarLower;
        private System.Windows.Forms.TrackBar trackBarUpper;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lowLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label highLbl;
        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FlowLayoutPanel rowLayout;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
    }
}