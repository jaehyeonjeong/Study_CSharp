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
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();

            LoginView loginView = new LoginView();
            //ILoginView loginView = new LoginView();
            new LoginPresenter(loginView);

            //Application.Run((Form)loginView);
            Application.Run(loginView);
        }
    }
}
