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
      linkSignUp = new LinkLabel();
      btnLogin = new Button();
      label2 = new Label();
      txtPassword = new TextBox();
      txtId = new TextBox();
      label1 = new Label();
      SuspendLayout();
      // 
      // linkSignUp
      // 
      linkSignUp.AutoSize = true;
      linkSignUp.Location = new Point(52, 73);
      linkSignUp.Name = "linkSignUp";
      linkSignUp.Size = new Size(55, 15);
      linkSignUp.TabIndex = 11;
      linkSignUp.TabStop = true;
      linkSignUp.Text = "회원가입";
      // 
      // btnLogin
      // 
      btnLogin.Location = new Point(158, 9);
      btnLogin.Name = "btnLogin";
      btnLogin.Size = new Size(75, 52);
      btnLogin.TabIndex = 10;
      btnLogin.Text = "로그인";
      btnLogin.UseVisualStyleBackColor = true;
      btnLogin.Click += btnLogin_Click;
      // 
      // label2
      // 
      label2.Location = new Point(12, 38);
      label2.Name = "label2";
      label2.Size = new Size(34, 23);
      label2.TabIndex = 9;
      label2.Text = "PW:";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtPassword
      // 
      txtPassword.Location = new Point(52, 38);
      txtPassword.Name = "txtPassword";
      txtPassword.PasswordChar = '*';
      txtPassword.Size = new Size(100, 23);
      txtPassword.TabIndex = 8;
      // 
      // txtId
      // 
      txtId.Location = new Point(52, 9);
      txtId.Name = "txtId";
      txtId.Size = new Size(100, 23);
      txtId.TabIndex = 7;
      // 
      // label1
      // 
      label1.Location = new Point(12, 9);
      label1.Name = "label1";
      label1.Size = new Size(34, 23);
      label1.TabIndex = 6;
      label1.Text = "ID:";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // LoginView
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(254, 108);
      Controls.Add(linkSignUp);
      Controls.Add(btnLogin);
      Controls.Add(label2);
      Controls.Add(txtPassword);
      Controls.Add(txtId);
      Controls.Add(label1);
      Name = "LoginView";
      Text = "LoginView";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private LinkLabel linkSignUp;
    private Button btnLogin;
    private Label label2;
    private TextBox txtPassword;
    private TextBox txtId;
    private Label label1;
  }
}