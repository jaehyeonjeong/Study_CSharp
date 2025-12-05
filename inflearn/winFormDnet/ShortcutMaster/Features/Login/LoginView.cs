using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutMaster.Features.Login
{
    public interface ILoginView : IView // IView 인터페이스 상속
    {
        // 델리데이트 호출 구문
        event Action OnLogin;
        event Action OnToSignUp;

        // 인터페이스에 들어갈 속성
        string UserId { get; set; } 
        string Password { get; set; }

        // 이미 있는 로그인 뷰의 속성 및 메서드는 IView에서 상속받아 사용
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
        public event Action OnLogin = default!; // null 허용
        public event Action OnToSignUp = default!;


        // Invoke : 델리게이트(delegate)나 이벤트(event)를 실행(호출)
        private void btnLogin_Click(object sender, EventArgs e) => OnLogin?.Invoke(); // null 조건부 연산자 사용, PRESENTER에게 알림

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)=> OnToSignUp?.Invoke(); 
    }
}
