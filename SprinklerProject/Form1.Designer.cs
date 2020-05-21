namespace SprinklerProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbtnGrayScale = new System.Windows.Forms.RadioButton();
            this.rbtnRGB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(185, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 488);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(167, 384);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(831, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(345, 488);
            this.textBox2.TabIndex = 5;
            // 
            // rbtnGrayScale
            // 
            this.rbtnGrayScale.AutoSize = true;
            this.rbtnGrayScale.Checked = true;
            this.rbtnGrayScale.Location = new System.Drawing.Point(22, 430);
            this.rbtnGrayScale.Name = "rbtnGrayScale";
            this.rbtnGrayScale.Size = new System.Drawing.Size(82, 16);
            this.rbtnGrayScale.TabIndex = 6;
            this.rbtnGrayScale.TabStop = true;
            this.rbtnGrayScale.Text = "GrayScale";
            this.rbtnGrayScale.UseVisualStyleBackColor = true;
            this.rbtnGrayScale.CheckedChanged += new System.EventHandler(this.rbtnGrayScale_CheckedChanged);
            // 
            // rbtnRGB
            // 
            this.rbtnRGB.AutoSize = true;
            this.rbtnRGB.Location = new System.Drawing.Point(110, 430);
            this.rbtnRGB.Name = "rbtnRGB";
            this.rbtnRGB.Size = new System.Drawing.Size(48, 16);
            this.rbtnRGB.TabIndex = 7;
            this.rbtnRGB.Text = "RGB";
            this.rbtnRGB.UseVisualStyleBackColor = true;
            this.rbtnRGB.CheckedChanged += new System.EventHandler(this.rbtnRGB_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 509);
            this.Controls.Add(this.rbtnRGB);
            this.Controls.Add(this.rbtnGrayScale);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton rbtnGrayScale;
        private System.Windows.Forms.RadioButton rbtnRGB;
    }
}

