using ShortcutMaster.Features.Base;
using ShortcutMaster.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.Login
{
    public class LoginPresenter : PresenterBase<ILoginView>
    {
        private readonly IFormHandler _formHandler;

        public LoginPresenter(IFormHandler formHandler)
        {
            this._formHandler = formHandler;
        }

        // View는 PresenterBase에서 필드로 상속받아 사용
        public override void Initialize()   // 상속 메소드에서 구현
        {
            View.OnLogin += View_OnLogin; // 델리게이트 이벤트 구독, 이벤트 핸들러 메서드 연결
            View.OnToSignUp += View_OnToSignUp; // 회원가입 뷰 클릭시 회원가입 이벤트 핸들러 메서드 연결
        }

        private void View_OnToSignUp()
        {
            _formHandler.ShowSignUpView();
        }

        private void View_OnLogin()    // View에서 Present로 호출되는 구간
        {
            View.ShowMessage($"UserId: {View.UserId}, Password: {View.Password}");
        }
    }
}
