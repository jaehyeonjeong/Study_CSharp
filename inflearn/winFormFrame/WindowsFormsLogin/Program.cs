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

            // UIHandler, Singleton : 하나의 인스턴스만 생성, Transient : 요청할 때마다 새 인스턴스 생성
            services.AddSingleton<IFormHandler, FormHandler>();
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
            var formHandler = serviceProvider.GetRequiredService<IFormHandler>();

            Application.Run(formHandler.CreateLoginView()); // 애플리케이션 실행
        }
    }
}
