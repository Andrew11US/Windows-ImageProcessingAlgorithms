namespace ImageProcessingAlgorithms
{
    partial class CannyView
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
            this.applyBtn = new System.Windows.Forms.Button();
            this.rowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lowLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.highLbl = new System.Windows.Forms.Label();
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.trackBarUpper = new System.Windows.Forms.TrackBar();
            this.trackBarLower = new System.Windows.Forms.TrackBar();
            this.rowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(472, 403);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(166, 61);
            this.applyBtn.TabIndex = 4;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
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
            this.rowLayout.Location = new System.Drawing.Point(12, 301);
            this.rowLayout.Name = "rowLayout";
            this.rowLayout.Size = new System.Drawing.Size(1095, 58);
            this.rowLayout.TabIndex = 18;
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
            this.histogramPanel.Location = new System.Drawing.Point(12, 12);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(1095, 167);
            this.histogramPanel.TabIndex = 17;
            this.histogramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPanel_Paint);
            // 
            // trackBarUpper
            // 
            this.trackBarUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarUpper.Location = new System.Drawing.Point(12, 237);
            this.trackBarUpper.Maximum = 255;
            this.trackBarUpper.Name = "trackBarUpper";
            this.trackBarUpper.Size = new System.Drawing.Size(1095, 80);
            this.trackBarUpper.TabIndex = 16;
            this.trackBarUpper.Value = 255;
            this.trackBarUpper.Scroll += new System.EventHandler(this.trackBarHigh_Scroll);
            // 
            // trackBarLower
            // 
            this.trackBarLower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarLower.Location = new System.Drawing.Point(9, 185);
            this.trackBarLower.Maximum = 255;
            this.trackBarLower.Name = "trackBarLower";
            this.trackBarLower.Size = new System.Drawing.Size(1108, 80);
            this.trackBarLower.TabIndex = 15;
            this.trackBarLower.Scroll += new System.EventHandler(this.trackBarLow_Scroll);
            // 
            // CannyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 864);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.rowLayout);
            this.Controls.Add(this.histogramPanel);
            this.Controls.Add(this.trackBarUpper);
            this.Controls.Add(this.trackBarLower);
            this.Name = "CannyView";
            this.Text = "CannyView";
            this.rowLayout.ResumeLayout(false);
            this.rowLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.FlowLayoutPanel rowLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lowLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label highLbl;
        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.TrackBar trackBarUpper;
        private System.Windows.Forms.TrackBar trackBarLower;
    }
}