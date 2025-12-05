namespace ShortcutMaster.Features.Login
{
    partial class LoginView
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
            txtId = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            linkSignUp = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 27);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "ID : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 64);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "PW : ";
            // 
            // txtId
            // 
            txtId.Location = new Point(93, 24);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(93, 61);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(223, 24);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 60);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkSignUp
            // 
            linkSignUp.AutoSize = true;
            linkSignUp.Location = new Point(93, 99);
            linkSignUp.Name = "linkSignUp";
            linkSignUp.Size = new Size(55, 15);
            linkSignUp.TabIndex = 5;
            linkSignUp.TabStop = true;
            linkSignUp.Text = "회원가입";
            linkSignUp.LinkClicked += linkSignUp_LinkClicked;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 143);
            Controls.Add(linkSignUp);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginView";
            Text = "LoginView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtId;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel linkSignUp;
    }
}