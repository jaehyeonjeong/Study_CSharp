using Microsoft.Extensions.DependencyInjection;
using ShortcutMaster.Features.Login;
using ShortcutMaster.Features.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.UIHandler
{
    public interface IFormHandler
    {
        LoginView CreateLoginView();
        void ShowSignUpView(SignUpArgs args);
    }

    public class FormHandler : IFormHandler
    {
        private readonly IPresenterFactory _presenterFactory;

        public FormHandler(IPresenterFactory presenterFactory)
        {
            this._presenterFactory = presenterFactory;
        }

        public LoginView CreateLoginView()
        {
            // 컴퓨터 서비스를 이용해서 로케이터 패턴으로 로그인 프레젠터 생성 후 

            LoginView loginView = new LoginView();  // 뷰 객체에서 직접 생성
            _presenterFactory.Create<ILoginView, LoginPresenter>(loginView);

            return loginView;
        }

        public void ShowSignUpView(SignUpArgs args)    // 회원가입 프레젠터 생성
        {
            SignUpView signUpView = new SignUpView();
            _presenterFactory.Create<ISignUpView, SignUpPresenter, SignUpArgs>(signUpView, args);
            signUpView.ShowDialog();    // 최상단 다이얼로그 생성
            signUpView.Dispose();       // 폼이 종료 되면 폼의 메모리가 바로 떨어지지 않기 때문에 dispose 선언
        }
    }
}
