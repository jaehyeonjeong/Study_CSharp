using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Base;
using WindowsFormsLogin.Feature.SignUp;
using WindowsFormsLogin.UIHandler;

namespace WindowsFormsLogin.Feature.Login
{
    public class LoginPresenter : PresenterBase<ILoginView>
    {
        private readonly IFormHandler _formHandler;

        public LoginPresenter(IFormHandler formHandler)
        {
            this._formHandler = formHandler;
        }

        public override void Initialize()
        {
            View.OnLogin += View_OnLogin; // 델리게이트 이벤트 구독, 이벤트 핸들러 메서드 연결
            View.OnToSignUp += View_OnSignUp;
        }

        private void View_OnSignUp()
        {
            _formHandler.ShowSignUpView(new SignUpArgs { UserId = View.UserId, Password = View.Password });
        }

        private void View_OnLogin()    // View에서 Present로 호출되는 구간
        {
            View.ShowMessage($"UserId: {View.UserId}, Password: {View.Password}");
        }
    }
}
