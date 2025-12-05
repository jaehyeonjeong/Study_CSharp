using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLogin.Feature.Login;
using WindowsFormsLogin.UIHandler;

namespace WindowsFormsLogin
{
    internal static class Program
    {
        // 의존성 주입 서비스를 등록
        static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<LoginPresenter>();
            services.AddTransient<IPresenterFactory, PresenterFactory>(); // 프레젠터 팩토리 등록(의존성 주입)

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();     // 서비스 프로바이더 구성

            // 컴퓨터 서비스를 이용해 로케이터 패턴 구현
            var presenterFactory = serviceProvider.GetRequiredService<IPresenterFactory>();

            // 뷰 객체 직접 생성
            LoginView loginView = new LoginView();

            // presenter 팩토리를 통해 프리젠터 생성 및 뷰와 연결
            presenterFactory.Create<ILoginView, LoginPresenter>(loginView);

            Application.Run(loginView); // 애플리케이션 실행
        }
    }
}
