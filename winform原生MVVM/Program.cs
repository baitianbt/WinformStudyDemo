using Microsoft.Extensions.DependencyInjection;
using winform原生MVVM登录界面Demo.Ioc;
using winform原生MVVM登录界面Demo.Services;
using winform原生MVVM登录界面Demo.ViewModels;
using winform原生MVVM登录界面Demo.Views;

namespace winform原生MVVM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceProvider = IoCContainer.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginViewModel = serviceProvider.GetService<LoginViewModel>();
            var loginForm = new LoginForm(loginViewModel);

            var databaseInitializer = serviceProvider.GetService<DatabaseInitializer>();
            databaseInitializer.InitializeDatabase();
            Application.Run(loginForm);
        }
    }
}