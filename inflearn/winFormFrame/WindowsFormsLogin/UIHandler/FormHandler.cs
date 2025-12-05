using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Login;
using WindowsFormsLogin.Feature.SignUp;

namespace WindowsFormsLogin.UIHandler
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
            LoginView loginView = new LoginView();
            _presenterFactory.Create<ILoginView, LoginPresenter>(loginView);

            return loginView;
        }

        public void ShowSignUpView(SignUpArgs args)
        {
            SignUpView signUpView = new SignUpView();
            _presenterFactory.Create<ISignUpView, SignUpPresenter, SignUpArgs>(signUpView, args);
            signUpView.ShowDialog();
            signUpView.Dispose();
        }
    }
}
