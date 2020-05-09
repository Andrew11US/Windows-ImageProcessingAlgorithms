namespace ImageProcessingAlgorithms
{
    partial class BlurSelectView
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
            this.label1 = new System.Windows.Forms.Label();
            this.thresholdLbl = new System.Windows.Forms.Label();
            this.maskSizeSelectorUpDown = new System.Windows.Forms.NumericUpDown();
            this.isolatedBtn = new System.Windows.Forms.RadioButton();
            this.reflectedBtn = new System.Windows.Forms.RadioButton();
            this.replicateBtn = new System.Windows.Forms.RadioButton();
            this.buttonsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskSizeSelectorUpDown)).BeginInit();
            this.buttonsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(89, 329);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(154, 77);
            this.applyBtn.TabIndex = 6;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            // 
            // lblLayout
            // 
            this.lblLayout.Controls.Add(this.label1);
            this.lblLayout.Controls.Add(this.thresholdLbl);
            this.lblLayout.Controls.Add(this.maskSizeSelectorUpDown);
            this.lblLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayout.Location = new System.Drawing.Point(12, 12);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(314, 56);
            this.lblLayout.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mask size:";
            // 
            // thresholdLbl
            // 
            this.thresholdLbl.AutoSize = true;
            this.thresholdLbl.Location = new System.Drawing.Point(167, 0);
            this.thresholdLbl.Name = "thresholdLbl";
            this.thresholdLbl.Size = new System.Drawing.Size(0, 32);
            this.thresholdLbl.TabIndex = 3;
            // 
            // maskSizeSelectorUpDown
            // 
            this.maskSizeSelectorUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.maskSizeSelectorUpDown.Location = new System.Drawing.Point(173, 3);
            this.maskSizeSelectorUpDown.Maximum = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.maskSizeSelectorUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maskSizeSelectorUpDown.Name = "maskSizeSelectorUpDown";
            this.maskSizeSelectorUpDown.Size = new System.Drawing.Size(120, 39);
            this.maskSizeSelectorUpDown.TabIndex = 13;
            this.maskSizeSelectorUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maskSizeSelectorUpDown.ValueChanged += new System.EventHandler(this.maskSizeSelectorUpDown_ValueChanged);
            // 
            // isolatedBtn
            // 
            this.isolatedBtn.AutoSize = true;
            this.isolatedBtn.Location = new System.Drawing.Point(3, 28);
            this.isolatedBtn.Name = "isolatedBtn";
            this.isolatedBtn.Size = new System.Drawing.Size(105, 29);
            this.isolatedBtn.TabIndex = 8;
            this.isolatedBtn.TabStop = true;
            this.isolatedBtn.Text = "Isolated";
            this.isolatedBtn.UseVisualStyleBackColor = true;
            this.isolatedBtn.CheckedChanged += new System.EventHandler(this.isolatedBtn_CheckedChanged);
            // 
            // reflectedBtn
            // 
            this.reflectedBtn.AutoSize = true;
            this.reflectedBtn.Location = new System.Drawing.Point(3, 63);
            this.reflectedBtn.Name = "reflectedBtn";
            this.reflectedBtn.Size = new System.Drawing.Size(96, 29);
            this.reflectedBtn.TabIndex = 9;
            this.reflectedBtn.TabStop = true;
            this.reflectedBtn.Text = "Reflect";
            this.reflectedBtn.UseVisualStyleBackColor = true;
            this.reflectedBtn.CheckedChanged += new System.EventHandler(this.reflectedBtn_CheckedChanged);
            // 
            // replicateBtn
            // 
            this.replicateBtn.AutoSize = true;
            this.replicateBtn.Location = new System.Drawing.Point(3, 98);
            this.replicateBtn.Name = "replicateBtn";
            this.replicateBtn.Size = new System.Drawing.Size(117, 29);
            this.replicateBtn.TabIndex = 10;
            this.replicateBtn.TabStop = true;
            this.replicateBtn.Text = "Replicate";
            this.replicateBtn.UseVisualStyleBackColor = true;
            this.replicateBtn.CheckedChanged += new System.EventHandler(this.replicateBtn_CheckedChanged);
            // 
            // buttonsLayout
            // 
            this.buttonsLayout.Controls.Add(this.label2);
            this.buttonsLayout.Controls.Add(this.isolatedBtn);
            this.buttonsLayout.Controls.Add(this.reflectedBtn);
            this.buttonsLayout.Controls.Add(this.replicateBtn);
            this.buttonsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.buttonsLayout.Location = new System.Drawing.Point(12, 87);
            this.buttonsLayout.Name = "buttonsLayout";
            this.buttonsLayout.Size = new System.Drawing.Size(231, 203);
            this.buttonsLayout.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select Border Fill Type:";
            // 
            // BlurSelectView
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 638);
            this.Controls.Add(this.buttonsLayout);
            this.Controls.Add(this.lblLayout);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BlurSelectView";
            this.Text = "BlurSelectView";
            this.lblLayout.ResumeLayout(false);
            this.lblLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskSizeSelectorUpDown)).EndInit();
            this.buttonsLayout.ResumeLayout(false);
            this.buttonsLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.FlowLayoutPanel lblLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label thresholdLbl;
        private System.Windows.Forms.RadioButton isolatedBtn;
        private System.Windows.Forms.RadioButton reflectedBtn;
        private System.Windows.Forms.RadioButton replicateBtn;
        private System.Windows.Forms.FlowLayoutPanel buttonsLayout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maskSizeSelectorUpDown;
    }
}