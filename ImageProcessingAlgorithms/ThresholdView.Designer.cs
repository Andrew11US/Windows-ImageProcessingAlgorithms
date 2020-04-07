namespace ImageProcessingAlgorithms
{
    partial class ThresholdView
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
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.thresholdSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.thresholdLbl = new System.Windows.Forms.Label();
            this.lblLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.applyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).BeginInit();
            this.lblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramPanel
            // 
            this.histogramPanel.Location = new System.Drawing.Point(12, 12);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(200, 100);
            this.histogramPanel.TabIndex = 0;
            this.histogramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPanel_Paint);
            // 
            // thresholdSlider
            // 
            this.thresholdSlider.Location = new System.Drawing.Point(12, 118);
            this.thresholdSlider.Maximum = 255;
            this.thresholdSlider.Name = "thresholdSlider";
            this.thresholdSlider.Size = new System.Drawing.Size(377, 80);
            this.thresholdSlider.TabIndex = 1;
            this.thresholdSlider.Value = 128;
            this.thresholdSlider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Threshold:";
            // 
            // thresholdLbl
            // 
            this.thresholdLbl.AutoSize = true;
            this.thresholdLbl.Location = new System.Drawing.Point(169, 0);
            this.thresholdLbl.Name = "thresholdLbl";
            this.thresholdLbl.Size = new System.Drawing.Size(66, 32);
            this.thresholdLbl.TabIndex = 3;
            this.thresholdLbl.Text = "128";
            // 
            // lblLayout
            // 
            this.lblLayout.Controls.Add(this.label1);
            this.lblLayout.Controls.Add(this.thresholdLbl);
            this.lblLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayout.Location = new System.Drawing.Point(25, 167);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(314, 100);
            this.lblLayout.TabIndex = 4;
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(33, 285);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(154, 77);
            this.applyBtn.TabIndex = 5;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            // 
            // ThresholdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 398);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.lblLayout);
            this.Controls.Add(this.thresholdSlider);
            this.Controls.Add(this.histogramPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ThresholdView";
            this.Text = "ThresholdView";
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).EndInit();
            this.lblLayout.ResumeLayout(false);
            this.lblLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.TrackBar thresholdSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label thresholdLbl;
        private System.Windows.Forms.FlowLayoutPanel lblLayout;
        private System.Windows.Forms.Button applyBtn;
    }
}