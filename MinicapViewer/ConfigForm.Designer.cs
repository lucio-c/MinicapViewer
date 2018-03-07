namespace MinicapViewer
{
    partial class ConfigForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scale1_btn = new System.Windows.Forms.RadioButton();
            this.scale2_btn = new System.Windows.Forms.RadioButton();
            this.scale3_btn = new System.Windows.Forms.RadioButton();
            this.scale4_btn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.orien90_btn = new System.Windows.Forms.RadioButton();
            this.orien0_btn = new System.Windows.Forms.RadioButton();
            this.enter_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scale1_btn);
            this.groupBox1.Controls.Add(this.scale2_btn);
            this.groupBox1.Controls.Add(this.scale3_btn);
            this.groupBox1.Controls.Add(this.scale4_btn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择显示比例";
            // 
            // scale1_btn
            // 
            this.scale1_btn.AutoSize = true;
            this.scale1_btn.Location = new System.Drawing.Point(22, 86);
            this.scale1_btn.Name = "scale1_btn";
            this.scale1_btn.Size = new System.Drawing.Size(47, 16);
            this.scale1_btn.TabIndex = 3;
            this.scale1_btn.Text = "1：1";
            this.scale1_btn.UseVisualStyleBackColor = true;
            // 
            // scale2_btn
            // 
            this.scale2_btn.AutoSize = true;
            this.scale2_btn.Checked = true;
            this.scale2_btn.Location = new System.Drawing.Point(22, 64);
            this.scale2_btn.Name = "scale2_btn";
            this.scale2_btn.Size = new System.Drawing.Size(47, 16);
            this.scale2_btn.TabIndex = 2;
            this.scale2_btn.TabStop = true;
            this.scale2_btn.Text = "1：2";
            this.scale2_btn.UseVisualStyleBackColor = true;
            // 
            // scale3_btn
            // 
            this.scale3_btn.AutoSize = true;
            this.scale3_btn.Location = new System.Drawing.Point(22, 42);
            this.scale3_btn.Name = "scale3_btn";
            this.scale3_btn.Size = new System.Drawing.Size(47, 16);
            this.scale3_btn.TabIndex = 1;
            this.scale3_btn.Text = "1：3";
            this.scale3_btn.UseVisualStyleBackColor = true;
            // 
            // scale4_btn
            // 
            this.scale4_btn.AutoSize = true;
            this.scale4_btn.Location = new System.Drawing.Point(22, 20);
            this.scale4_btn.Name = "scale4_btn";
            this.scale4_btn.Size = new System.Drawing.Size(47, 16);
            this.scale4_btn.TabIndex = 0;
            this.scale4_btn.Text = "1：4";
            this.scale4_btn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.orien90_btn);
            this.groupBox2.Controls.Add(this.orien0_btn);
            this.groupBox2.Location = new System.Drawing.Point(114, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择画面方向";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "(左)";
            // 
            // orien90_btn
            // 
            this.orien90_btn.AutoSize = true;
            this.orien90_btn.Location = new System.Drawing.Point(13, 48);
            this.orien90_btn.Name = "orien90_btn";
            this.orien90_btn.Size = new System.Drawing.Size(47, 16);
            this.orien90_btn.TabIndex = 1;
            this.orien90_btn.Text = "90°";
            this.orien90_btn.UseVisualStyleBackColor = true;
            // 
            // orien0_btn
            // 
            this.orien0_btn.AutoSize = true;
            this.orien0_btn.Checked = true;
            this.orien0_btn.Location = new System.Drawing.Point(13, 23);
            this.orien0_btn.Name = "orien0_btn";
            this.orien0_btn.Size = new System.Drawing.Size(41, 16);
            this.orien0_btn.TabIndex = 0;
            this.orien0_btn.TabStop = true;
            this.orien0_btn.Text = "0°";
            this.orien0_btn.UseVisualStyleBackColor = true;
            // 
            // enter_btn
            // 
            this.enter_btn.Location = new System.Drawing.Point(122, 98);
            this.enter_btn.Name = "enter_btn";
            this.enter_btn.Size = new System.Drawing.Size(75, 23);
            this.enter_btn.TabIndex = 2;
            this.enter_btn.Text = "确定";
            this.enter_btn.UseVisualStyleBackColor = true;
            this.enter_btn.Click += new System.EventHandler(this.enter_btn_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 132);
            this.Controls.Add(this.enter_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton scale1_btn;
        private System.Windows.Forms.RadioButton scale2_btn;
        private System.Windows.Forms.RadioButton scale3_btn;
        private System.Windows.Forms.RadioButton scale4_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton orien90_btn;
        private System.Windows.Forms.RadioButton orien0_btn;
        private System.Windows.Forms.Button enter_btn;
        private System.Windows.Forms.Label label1;
    }
}