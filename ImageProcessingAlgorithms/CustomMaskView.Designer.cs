namespace ImageProcessingAlgorithms
{
    partial class CustomMaskView
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
            this.autoCheckBox = new System.Windows.Forms.CheckBox();
            this.divisorBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mask7Box = new System.Windows.Forms.TextBox();
            this.mask8Box = new System.Windows.Forms.TextBox();
            this.mask9Box = new System.Windows.Forms.TextBox();
            this.mask4Box = new System.Windows.Forms.TextBox();
            this.mask5Box = new System.Windows.Forms.TextBox();
            this.mask6Box = new System.Windows.Forms.TextBox();
            this.mask3Box = new System.Windows.Forms.TextBox();
            this.mask2Box = new System.Windows.Forms.TextBox();
            this.mask1Box = new System.Windows.Forms.TextBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.matrixLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.divisorLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.isolatedBtn = new System.Windows.Forms.RadioButton();
            this.reflectedBtn = new System.Windows.Forms.RadioButton();
            this.replicateBtn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.matrixLayout.SuspendLayout();
            this.divisorLayout.SuspendLayout();
            this.buttonsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoCheckBox
            // 
            this.autoCheckBox.AutoSize = true;
            this.autoCheckBox.Checked = true;
            this.autoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCheckBox.Location = new System.Drawing.Point(61, 6);
            this.autoCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.autoCheckBox.Name = "autoCheckBox";
            this.autoCheckBox.Size = new System.Drawing.Size(76, 29);
            this.autoCheckBox.TabIndex = 27;
            this.autoCheckBox.Text = "auto";
            this.autoCheckBox.UseVisualStyleBackColor = true;
            this.autoCheckBox.CheckedChanged += new System.EventHandler(this.autoCheckBox_CheckedChanged);
            // 
            // divisorBox
            // 
            this.divisorBox.Enabled = false;
            this.divisorBox.Location = new System.Drawing.Point(6, 6);
            this.divisorBox.Margin = new System.Windows.Forms.Padding(6);
            this.divisorBox.Name = "divisorBox";
            this.divisorBox.Size = new System.Drawing.Size(43, 29);
            this.divisorBox.TabIndex = 26;
            this.divisorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.divisorBox.TextChanged += new System.EventHandler(this.divisorBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Divisor:";
            // 
            // mask7Box
            // 
            this.mask7Box.Location = new System.Drawing.Point(6, 88);
            this.mask7Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask7Box.Name = "mask7Box";
            this.mask7Box.Size = new System.Drawing.Size(43, 29);
            this.mask7Box.TabIndex = 20;
            this.mask7Box.Text = "1";
            this.mask7Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask7Box.TextChanged += new System.EventHandler(this.mask7Box_TextChanged);
            // 
            // mask8Box
            // 
            this.mask8Box.Location = new System.Drawing.Point(61, 88);
            this.mask8Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask8Box.Name = "mask8Box";
            this.mask8Box.Size = new System.Drawing.Size(43, 29);
            this.mask8Box.TabIndex = 21;
            this.mask8Box.Text = "1";
            this.mask8Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask8Box.TextChanged += new System.EventHandler(this.mask8Box_TextChanged);
            // 
            // mask9Box
            // 
            this.mask9Box.Location = new System.Drawing.Point(116, 88);
            this.mask9Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask9Box.Name = "mask9Box";
            this.mask9Box.Size = new System.Drawing.Size(43, 29);
            this.mask9Box.TabIndex = 22;
            this.mask9Box.Text = "1";
            this.mask9Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask9Box.TextChanged += new System.EventHandler(this.mask9Box_TextChanged);
            // 
            // mask4Box
            // 
            this.mask4Box.Location = new System.Drawing.Point(6, 47);
            this.mask4Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask4Box.Name = "mask4Box";
            this.mask4Box.Size = new System.Drawing.Size(43, 29);
            this.mask4Box.TabIndex = 17;
            this.mask4Box.Text = "1";
            this.mask4Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask4Box.TextChanged += new System.EventHandler(this.mask4Box_TextChanged);
            // 
            // mask5Box
            // 
            this.mask5Box.Location = new System.Drawing.Point(61, 47);
            this.mask5Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask5Box.Name = "mask5Box";
            this.mask5Box.Size = new System.Drawing.Size(43, 29);
            this.mask5Box.TabIndex = 18;
            this.mask5Box.Text = "1";
            this.mask5Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask5Box.TextChanged += new System.EventHandler(this.mask5Box_TextChanged);
            // 
            // mask6Box
            // 
            this.mask6Box.Location = new System.Drawing.Point(116, 47);
            this.mask6Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask6Box.Name = "mask6Box";
            this.mask6Box.Size = new System.Drawing.Size(43, 29);
            this.mask6Box.TabIndex = 19;
            this.mask6Box.Text = "1";
            this.mask6Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask6Box.TextChanged += new System.EventHandler(this.mask6Box_TextChanged);
            // 
            // mask3Box
            // 
            this.mask3Box.Location = new System.Drawing.Point(116, 6);
            this.mask3Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask3Box.Name = "mask3Box";
            this.mask3Box.Size = new System.Drawing.Size(43, 29);
            this.mask3Box.TabIndex = 16;
            this.mask3Box.Text = "1";
            this.mask3Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask3Box.TextChanged += new System.EventHandler(this.mask3Box_TextChanged);
            // 
            // mask2Box
            // 
            this.mask2Box.Location = new System.Drawing.Point(61, 6);
            this.mask2Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask2Box.Name = "mask2Box";
            this.mask2Box.Size = new System.Drawing.Size(43, 29);
            this.mask2Box.TabIndex = 15;
            this.mask2Box.Text = "1";
            this.mask2Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask2Box.TextChanged += new System.EventHandler(this.mask2Box_TextChanged);
            // 
            // mask1Box
            // 
            this.mask1Box.Location = new System.Drawing.Point(6, 6);
            this.mask1Box.Margin = new System.Windows.Forms.Padding(6);
            this.mask1Box.Name = "mask1Box";
            this.mask1Box.Size = new System.Drawing.Size(43, 29);
            this.mask1Box.TabIndex = 14;
            this.mask1Box.Text = "1";
            this.mask1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mask1Box.TextChanged += new System.EventHandler(this.mask1Box_TextChanged);
            // 
            // applyBtn
            // 
            this.applyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBtn.Location = new System.Drawing.Point(160, 279);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(154, 77);
            this.applyBtn.TabIndex = 28;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // matrixLayout
            // 
            this.matrixLayout.BackColor = System.Drawing.Color.Transparent;
            this.matrixLayout.Controls.Add(this.mask1Box);
            this.matrixLayout.Controls.Add(this.mask2Box);
            this.matrixLayout.Controls.Add(this.mask3Box);
            this.matrixLayout.Controls.Add(this.mask4Box);
            this.matrixLayout.Controls.Add(this.mask5Box);
            this.matrixLayout.Controls.Add(this.mask6Box);
            this.matrixLayout.Controls.Add(this.mask7Box);
            this.matrixLayout.Controls.Add(this.mask8Box);
            this.matrixLayout.Controls.Add(this.mask9Box);
            this.matrixLayout.Location = new System.Drawing.Point(15, 12);
            this.matrixLayout.Name = "matrixLayout";
            this.matrixLayout.Size = new System.Drawing.Size(183, 144);
            this.matrixLayout.TabIndex = 29;
            // 
            // divisorLayout
            // 
            this.divisorLayout.Controls.Add(this.divisorBox);
            this.divisorLayout.Controls.Add(this.autoCheckBox);
            this.divisorLayout.Location = new System.Drawing.Point(15, 193);
            this.divisorLayout.Name = "divisorLayout";
            this.divisorLayout.Size = new System.Drawing.Size(206, 51);
            this.divisorLayout.TabIndex = 30;
            // 
            // buttonsLayout
            // 
            this.buttonsLayout.Controls.Add(this.isolatedBtn);
            this.buttonsLayout.Controls.Add(this.reflectedBtn);
            this.buttonsLayout.Controls.Add(this.replicateBtn);
            this.buttonsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.buttonsLayout.Location = new System.Drawing.Point(270, 59);
            this.buttonsLayout.Name = "buttonsLayout";
            this.buttonsLayout.Size = new System.Drawing.Size(209, 114);
            this.buttonsLayout.TabIndex = 31;
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
            this.reflectedBtn.Location = new System.Drawing.Point(3, 38);
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
            this.replicateBtn.Location = new System.Drawing.Point(3, 73);
            this.replicateBtn.Name = "replicateBtn";
            this.replicateBtn.Size = new System.Drawing.Size(117, 29);
            this.replicateBtn.TabIndex = 10;
            this.replicateBtn.TabStop = true;
            this.replicateBtn.Text = "Replicate";
            this.replicateBtn.UseVisualStyleBackColor = true;
            this.replicateBtn.CheckedChanged += new System.EventHandler(this.replicateBtn_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Select Border Fill Type:";
            // 
            // CustomMaskView
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 553);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonsLayout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.divisorLayout);
            this.Controls.Add(this.matrixLayout);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomMaskView";
            this.Text = "CustomMaskView";
            this.matrixLayout.ResumeLayout(false);
            this.matrixLayout.PerformLayout();
            this.divisorLayout.ResumeLayout(false);
            this.divisorLayout.PerformLayout();
            this.buttonsLayout.ResumeLayout(false);
            this.buttonsLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autoCheckBox;
        private System.Windows.Forms.TextBox divisorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mask7Box;
        private System.Windows.Forms.TextBox mask8Box;
        private System.Windows.Forms.TextBox mask9Box;
        private System.Windows.Forms.TextBox mask4Box;
        private System.Windows.Forms.TextBox mask5Box;
        private System.Windows.Forms.TextBox mask6Box;
        private System.Windows.Forms.TextBox mask3Box;
        private System.Windows.Forms.TextBox mask2Box;
        private System.Windows.Forms.TextBox mask1Box;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.FlowLayoutPanel matrixLayout;
        private System.Windows.Forms.FlowLayoutPanel divisorLayout;
        private System.Windows.Forms.FlowLayoutPanel buttonsLayout;
        private System.Windows.Forms.RadioButton isolatedBtn;
        private System.Windows.Forms.RadioButton reflectedBtn;
        private System.Windows.Forms.RadioButton replicateBtn;
        private System.Windows.Forms.Label label2;
    }
}