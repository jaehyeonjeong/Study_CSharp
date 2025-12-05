using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLogin.Feature.Login;

namespace WindowsFormsLogin
{
    internal static class Program
    {
        // 의존성 주입 서비스를 등록
        static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<LoginPresenter>();

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
            LoginPresenter loginPresenter = serviceProvider.GetRequiredService<LoginPresenter>();

            // 뷰 객체 직접 생성
            LoginView loginView = new LoginView();

            loginPresenter.SetView(loginView); // 프레젠터에 뷰 설정

            Application.Run(loginView); // 애플리케이션 실행
        }
    }
}
