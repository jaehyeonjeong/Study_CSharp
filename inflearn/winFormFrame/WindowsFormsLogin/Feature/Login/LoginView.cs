using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLogin.Feature.Base;

namespace WindowsFormsLogin.Feature.Login
{
    public interface ILoginView : IView
    {
        // 델리데이트 호출 구문
        event Action OnLogin;
        event Action OnToSignUp;

        // 인터페이스에 들어갈 속성
        string UserId { get; set; }
        string Password { get; set; }
    }
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }
        // 로그인 뷰 인터페이스 구현
        public string UserId { get => txtId.Text.Trim(); set => txtId.Text = value; } // Trim()을 사용하여 공백 제거
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }

        // 델리데이트 이벤트 구현
        public event Action OnLogin = default; // null 허용
        public event Action OnToSignUp = default;

        // Trim()은 비밀번호에 사용하지 않음, 공백도 유효한 비밀번호일 수 있으므로

        // IView 인터페이스 구현 .NetFramework환경에선 직접  상속받아 구현
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResult ShowDialog(string name, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(name, caption, buttons);
        }

        private void btnLogin_Click(object sender, EventArgs e) => OnLogin?.Invoke(); // null 조건부 연산자 사용, PRESENTER에게 알림
        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OnToSignUp?.Invoke();
    }
}
