using Microsoft.Extensions.DependencyInjection;
using ShortcutMaster.Features.Login;
using System.ComponentModel.Design;

namespace ShortcutMaster
{
    internal static class Program
    {
        // 의존성 주입 서비스를 등록하는 메서드를 생성
        static IServiceProvider ConfigureServices()     // 서비스 등록 코드
        {
            IServiceCollection services = new ServiceCollection();

            //services.AddTransient<LoginPresenter>(_ => new LoginPresenter(new LoginView()));        // 의존성 주입을 위한 서비스 등록
            services.AddTransient<LoginPresenter>();        // 의존성 주입을 위한 서비스 등록

            return services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
           
            IServiceProvider serviceProvider = ConfigureServices(); // 서비스 프로바이더 구성

            // 컴퓨터 서비스를 이용해서 로케이터 패턴으로 로그인 프레젠터 생성 후 
            LoginPresenter loginPresenter = serviceProvider.GetRequiredService<LoginPresenter>();   // LoginPresenter 인스턴스 생성

            // 뷰 객체에서 직접 생성
            LoginView loginView = new LoginView();
            loginPresenter.SetView(loginView);  // 프레젠터 안에 SetView 메서드로 뷰 설정
          
            Application.Run(loginView); // 마지막으로 어플리케이션 실행 
        }
    }
}