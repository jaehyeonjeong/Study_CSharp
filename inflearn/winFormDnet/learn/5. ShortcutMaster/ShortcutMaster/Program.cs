using Microsoft.Extensions.DependencyInjection;
using ShortcutMaster.Features.Login;
using ShortcutMaster.UIHandler;

namespace ShortcutMaster
{
  internal static class Program
  {
    static IServiceProvider ConfigureServices()
    {
      IServiceCollection services = new ServiceCollection();

      services.AddTransient<LoginPresenter>();
      services.AddTransient<IPresenterFactory, PresenterFactory>();

      return services.BuildServiceProvider();
    }

    [STAThread]
    static void Main()
    {
      ApplicationConfiguration.Initialize();

      IServiceProvider serviceProvider = ConfigureServices();
      var presenterFactory = serviceProvider.GetRequiredService<IPresenterFactory>();
      LoginView loginView = new LoginView();
      presenterFactory.Create<ILoginView, LoginPresenter>(loginView);
     
      Application.Run(loginView);
    }
  }
}