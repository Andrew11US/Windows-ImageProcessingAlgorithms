namespace ImageProcessingAlgorithms
{
    partial class PosterizeView
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
            this.lblLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.thresholdLbl = new System.Windows.Forms.Label();
            this.thresholdSlider = new System.Windows.Forms.TrackBar();
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.lblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(54, 415);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(154, 77);
            this.applyBtn.TabIndex = 6;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            // 
            // lblLayout
            // 
            this.lblLayout.Controls.Add(this.label3);
            this.lblLayout.Controls.Add(this.thresholdLbl);
            this.lblLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayout.Location = new System.Drawing.Point(83, 285);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(467, 100);
            this.lblLayout.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of gray levels:";
            // 
            // thresholdLbl
            // 
            this.thresholdLbl.AutoSize = true;
            this.thresholdLbl.Location = new System.Drawing.Point(328, 0);
            this.thresholdLbl.Name = "thresholdLbl";
            this.thresholdLbl.Size = new System.Drawing.Size(66, 32);
            this.thresholdLbl.TabIndex = 3;
            this.thresholdLbl.Text = "128";
            // 
            // thresholdSlider
            // 
            this.thresholdSlider.Location = new System.Drawing.Point(41, 199);
            this.thresholdSlider.Maximum = 255;
            this.thresholdSlider.Name = "thresholdSlider";
            this.thresholdSlider.Size = new System.Drawing.Size(377, 80);
            this.thresholdSlider.TabIndex = 8;
            this.thresholdSlider.Value = 128;
            this.thresholdSlider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // histogramPanel
            // 
            this.histogramPanel.Location = new System.Drawing.Point(113, 66);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(200, 100);
            this.histogramPanel.TabIndex = 9;
            this.histogramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPanel_Paint);
            // 
            // PosterizeView
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 550);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.lblLayout);
            this.Controls.Add(this.histogramPanel);
            this.Controls.Add(this.thresholdSlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PosterizeView";
            this.Text = "PosterizeView";
            this.lblLayout.ResumeLayout(false);
            this.lblLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.FlowLayoutPanel lblLayout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label thresholdLbl;
        private System.Windows.Forms.TrackBar thresholdSlider;
        private System.Windows.Forms.Panel histogramPanel;
    }
}