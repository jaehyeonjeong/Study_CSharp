using Microsoft.Extensions.DependencyInjection;
using ShortcutMaster.Features.Login;
using ShortcutMaster.Features.SignUp;
using ShortcutMaster.UIHandler;
using System.ComponentModel.Design;

namespace ShortcutMaster
{
    internal static class Program
    {
        // 의존성 주입 서비스를 등록
        static IServiceProvider ConfigureServices()  
        {
            IServiceCollection services = new ServiceCollection();

            // Presenters
            services.AddTransient<LoginPresenter>();
            services.AddTransient<SignUpPresenter>();

            // UIHandler
            services.AddSingleton<IFormHandler, FormHandler>();
            services.AddTransient<IPresenterFactory, PresenterFactory>(); // 프레젠터 팩토리 등록(의존성 주입)

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

            var formHandler = serviceProvider.GetRequiredService<IFormHandler>();   // LoginPresenter 인스턴스 생성

            Application.Run(formHandler.CreateLoginView()); // 마지막으로 어플리케이션 실행 
        }
    }
}