using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Login;

namespace WindowsFormsLogin.UIHandler
{
    public interface IFormHandler
    {
        LoginView CreateLoginView();
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
    }
}
