namespace myOCR
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_show_image = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_WriteValue = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_ReadValue = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 313);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_show_image
            // 
            this.btn_show_image.Location = new System.Drawing.Point(11, 347);
            this.btn_show_image.Margin = new System.Windows.Forms.Padding(2);
            this.btn_show_image.Name = "btn_show_image";
            this.btn_show_image.Size = new System.Drawing.Size(101, 31);
            this.btn_show_image.TabIndex = 3;
            this.btn_show_image.Text = "显示画面";
            this.btn_show_image.UseVisualStyleBackColor = true;
            this.btn_show_image.Click += new System.EventHandler(this.btn_show_image_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(389, 399);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 21);
            this.textBox1.TabIndex = 5;
            // 
            // btn_WriteValue
            // 
            this.btn_WriteValue.Location = new System.Drawing.Point(499, 449);
            this.btn_WriteValue.Name = "btn_WriteValue";
            this.btn_WriteValue.Size = new System.Drawing.Size(92, 29);
            this.btn_WriteValue.TabIndex = 6;
            this.btn_WriteValue.Text = "WritePLC";
            this.btn_WriteValue.UseVisualStyleBackColor = true;
            this.btn_WriteValue.Click += new System.EventHandler(this.btn_WriteValue_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(389, 454);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(99, 21);
            this.textBox2.TabIndex = 7;
            // 
            // btn_ReadValue
            // 
            this.btn_ReadValue.Location = new System.Drawing.Point(503, 393);
            this.btn_ReadValue.Name = "btn_ReadValue";
            this.btn_ReadValue.Size = new System.Drawing.Size(90, 27);
            this.btn_ReadValue.TabIndex = 8;
            this.btn_ReadValue.Text = "ReadPLC";
            this.btn_ReadValue.UseVisualStyleBackColor = true;
            this.btn_ReadValue.Click += new System.EventHandler(this.btn_ReadValue_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "iniOCR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ReadValue);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_WriteValue);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_show_image);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_show_image;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_WriteValue;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_ReadValue;
        private System.Windows.Forms.Button button1;
    }
}

