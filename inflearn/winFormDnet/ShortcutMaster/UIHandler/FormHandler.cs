using Microsoft.Extensions.DependencyInjection;
using ShortcutMaster.Features.Login;
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
            //var presenterFactory = serviceProvider.GetRequiredService<IPresenterFactory>();   // LoginPresenter 인스턴스 생성

            LoginView loginView = new LoginView();  // 뷰 객체에서 직접 생성
            _presenterFactory.Create<ILoginView, LoginPresenter>(loginView);

            return loginView;
        }
    }
}
