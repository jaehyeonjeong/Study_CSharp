namespace ShortcutMaster.Features.SignUp
{
    partial class SignUpView
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtId = new TextBox();
            txtPw = new TextBox();
            txtPwConFirm = new TextBox();
            txtEmail = new TextBox();
            btnSignUp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "아이디 : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 73);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "비밀번호 : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 116);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 2;
            label3.Text = "비밀번호 확인 : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 159);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 3;
            label4.Text = "email : ";
            // 
            // txtId
            // 
            txtId.Location = new Point(129, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtPw
            // 
            txtPw.Location = new Point(129, 70);
            txtPw.Name = "txtPw";
            txtPw.Size = new Size(100, 23);
            txtPw.TabIndex = 5;
            txtPw.TextChanged += txtPw_TextChanged;
            // 
            // txtPwConFirm
            // 
            txtPwConFirm.Location = new Point(129, 113);
            txtPwConFirm.Name = "txtPwConFirm";
            txtPwConFirm.Size = new Size(100, 23);
            txtPwConFirm.TabIndex = 6;
            txtPwConFirm.TextChanged += txtPwConFirm_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(129, 156);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 7;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(29, 193);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(200, 51);
            btnSignUp.TabIndex = 8;
            btnSignUp.Text = "회원가입";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // SignUpView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 269);
            Controls.Add(btnSignUp);
            Controls.Add(txtEmail);
            Controls.Add(txtPwConFirm);
            Controls.Add(txtPw);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SignUpView";
            Text = "SignUpView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtId;
        private TextBox txtPw;
        private TextBox txtPwConFirm;
        private TextBox txtEmail;
        private Button btnSignUp;
    }
}