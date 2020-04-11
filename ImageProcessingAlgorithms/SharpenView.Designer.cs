namespace ImageProcessingAlgorithms
{
    partial class SharpenView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpenView));
            this.applyBtn = new System.Windows.Forms.Button();
            this.mask1Btn = new System.Windows.Forms.RadioButton();
            this.mask2Btn = new System.Windows.Forms.RadioButton();
            this.mask3Btn = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.isolatedBtn = new System.Windows.Forms.RadioButton();
            this.reflectedBtn = new System.Windows.Forms.RadioButton();
            this.replicateBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.buttonsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(236, 396);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(154, 77);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            // 
            // mask1Btn
            // 
            this.mask1Btn.AutoSize = true;
            this.mask1Btn.Location = new System.Drawing.Point(78, 185);
            this.mask1Btn.Name = "mask1Btn";
            this.mask1Btn.Size = new System.Drawing.Size(101, 29);
            this.mask1Btn.TabIndex = 8;
            this.mask1Btn.TabStop = true;
            this.mask1Btn.Text = "Mask 1";
            this.mask1Btn.UseVisualStyleBackColor = true;
            this.mask1Btn.CheckedChanged += new System.EventHandler(this.mask1Btn_CheckedChanged);
            // 
            // mask2Btn
            // 
            this.mask2Btn.AutoSize = true;
            this.mask2Btn.Location = new System.Drawing.Point(247, 185);
            this.mask2Btn.Name = "mask2Btn";
            this.mask2Btn.Size = new System.Drawing.Size(101, 29);
            this.mask2Btn.TabIndex = 9;
            this.mask2Btn.TabStop = true;
            this.mask2Btn.Text = "Mask 2";
            this.mask2Btn.UseVisualStyleBackColor = true;
            this.mask2Btn.CheckedChanged += new System.EventHandler(this.mask2Btn_CheckedChanged);
            // 
            // mask3Btn
            // 
            this.mask3Btn.AutoSize = true;
            this.mask3Btn.Location = new System.Drawing.Point(442, 185);
            this.mask3Btn.Name = "mask3Btn";
            this.mask3Btn.Size = new System.Drawing.Size(101, 29);
            this.mask3Btn.TabIndex = 10;
            this.mask3Btn.TabStop = true;
            this.mask3Btn.Text = "Mask 3";
            this.mask3Btn.UseVisualStyleBackColor = true;
            this.mask3Btn.CheckedChanged += new System.EventHandler(this.mask3Btn_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 107);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(247, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(143, 107);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(442, 59);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(137, 107);
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // buttonsLayout
            // 
            this.buttonsLayout.Controls.Add(this.isolatedBtn);
            this.buttonsLayout.Controls.Add(this.reflectedBtn);
            this.buttonsLayout.Controls.Add(this.replicateBtn);
            this.buttonsLayout.Location = new System.Drawing.Point(78, 270);
            this.buttonsLayout.Name = "buttonsLayout";
            this.buttonsLayout.Size = new System.Drawing.Size(407, 53);
            this.buttonsLayout.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select Border Fill Type:";
            // 
            // isolatedBtn
            // 
            this.isolatedBtn.AutoSize = true;
            this.isolatedBtn.Location = new System.Drawing.Point(3, 3);
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
            this.reflectedBtn.Location = new System.Drawing.Point(114, 3);
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
            this.replicateBtn.Location = new System.Drawing.Point(216, 3);
            this.replicateBtn.Name = "replicateBtn";
            this.replicateBtn.Size = new System.Drawing.Size(117, 29);
            this.replicateBtn.TabIndex = 10;
            this.replicateBtn.TabStop = true;
            this.replicateBtn.Text = "Replicate";
            this.replicateBtn.UseVisualStyleBackColor = true;
            this.replicateBtn.CheckedChanged += new System.EventHandler(this.replicateBtn_CheckedChanged);
            // 
            // SharpenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 529);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonsLayout);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mask2Btn);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.mask1Btn);
            this.Controls.Add(this.mask3Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SharpenView";
            this.Text = "SharpenView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.buttonsLayout.ResumeLayout(false);
            this.buttonsLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.RadioButton mask1Btn;
        private System.Windows.Forms.RadioButton mask2Btn;
        private System.Windows.Forms.RadioButton mask3Btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel buttonsLayout;
        private System.Windows.Forms.RadioButton isolatedBtn;
        private System.Windows.Forms.RadioButton reflectedBtn;
        private System.Windows.Forms.RadioButton replicateBtn;
        private System.Windows.Forms.Label label2;
    }
}