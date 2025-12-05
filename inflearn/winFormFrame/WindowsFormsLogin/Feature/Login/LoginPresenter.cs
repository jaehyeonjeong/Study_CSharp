using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLogin.Feature.Login
{
    public class LoginPresenter
    {
        private ILoginView _loginView;

        // 생성자
        public LoginPresenter(ILoginView loginView) // 매개 변수 생성
        {
            this._loginView = loginView;
            _loginView.OnLogin += _view_OnLogin; // 델리게이트 이벤트 구독, 이벤트 핸들러 메서드 연결
        }

        private void _view_OnLogin()    // View에서 Present로 호출되는 구간
        {
            _loginView.SendMessage($"UserId: {_loginView.UserId}, Password: {_loginView.Password}");
        }
    }
}
