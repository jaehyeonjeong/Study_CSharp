using ShortcutMaster.Features.Login;

namespace ShortcutMaster
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            LoginView loginView = new LoginView();
            //ILoginView loginView = new LoginView();
            new LoginPresenter(loginView);

            //Application.Run((Form)loginView);
            Application.Run(loginView);
        }
    }
}