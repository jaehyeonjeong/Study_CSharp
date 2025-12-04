namespace WindowsFormsApp9
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
            this.uc1 = new WindowsFormsApp9.UserControl1();
            this.uc2 = new WindowsFormsApp9.UserControl1();
            this.uc3 = new WindowsFormsApp9.UserControl1();
            this.SuspendLayout();
            // 
            // uc1
            // 
            this.uc1.Location = new System.Drawing.Point(0, 0);
            this.uc1.Name = "uc1";
            this.uc1.Size = new System.Drawing.Size(898, 178);
            this.uc1.TabIndex = 0;
            // 
            // uc2
            // 
            this.uc2.Location = new System.Drawing.Point(0, 184);
            this.uc2.Name = "uc2";
            this.uc2.Size = new System.Drawing.Size(898, 178);
            this.uc2.TabIndex = 1;
            // 
            // uc3
            // 
            this.uc3.Location = new System.Drawing.Point(0, 368);
            this.uc3.Name = "uc3";
            this.uc3.Size = new System.Drawing.Size(898, 178);
            this.uc3.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.uc3);
            this.Controls.Add(this.uc2);
            this.Controls.Add(this.uc1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 uc1;
        private UserControl1 uc2;
        private UserControl1 uc3;
    }
}

