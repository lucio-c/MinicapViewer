namespace MinicapViewer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.deviceImageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deviceImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceImageBox
            // 
            this.deviceImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deviceImageBox.Location = new System.Drawing.Point(12, 12);
            this.deviceImageBox.Name = "deviceImageBox";
            this.deviceImageBox.Size = new System.Drawing.Size(183, 152);
            this.deviceImageBox.TabIndex = 2;
            this.deviceImageBox.TabStop = false;
            this.deviceImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deviceImageBox_MouseDown);
            this.deviceImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deviceImageBox_MouseMove);
            this.deviceImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.deviceImageBox_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 181);
            this.Controls.Add(this.deviceImageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MinicapViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.deviceImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox deviceImageBox;
    }
}

