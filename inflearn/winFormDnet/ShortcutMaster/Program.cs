using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ShortcutMaster.Configs;
using ShortcutMaster.Data;
using ShortcutMaster.Features.Login;
using ShortcutMaster.Features.SignUp;
using ShortcutMaster.UIHandler;
using System.ComponentModel.Design;

namespace ShortcutMaster
{
    internal static class Program
    {
        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(context.Configuration.GetConnectionString("SQLite")); // json에서 만들어진 ConnectionString get
            });


            // Configuration
            services.Configure<AppSettings>(context.Configuration);
            services.AddSingleton<IAppSettings>(s => s.GetRequiredService<IOptions<AppSettings>>().Value); // Configuration 의존성 주입

            // Validators
            services.AddTransient<IValidator<SignUpViewModel>, SignUpViewModelValidator>();

            // Presenters
            services.AddTransient<LoginPresenter>();
            services.AddTransient<SignUpPresenter>();

            // UIHandler
            services.AddSingleton<IFormHandler, FormHandler>();
            services.AddTransient<IPresenterFactory, PresenterFactory>(); // 프레젠터 팩토리 등록(의존성 주입)
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // 이부분을 Hosting 기반으로 변경
            var builder = Host.CreateDefaultBuilder(args); // 명령줄 인수를 전달하기 위한 args

            // services: 사용하는 서비스 컬렉션 
            // hostcontext : 호스트가 빌드되는 과정에 중요한 정보들을 담고 있는 객체
            //builder.ConfigureServices((hostcontext, services) =>
            builder.ConfigureServices(ConfigureServices);
            var host = builder.Build();  // 빌드 받는 것을 host로 넘김

            var formHandler = host.Services.GetRequiredService<IFormHandler>();   // LoginPresenter 인스턴스 생성

            Application.Run(formHandler.CreateLoginView()); // 마지막으로 어플리케이션 실행 
        }
    }
}