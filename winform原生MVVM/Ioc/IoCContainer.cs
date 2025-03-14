using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using winform原生MVVM登录界面Demo.Services;
using winform原生MVVM登录界面Demo.ViewModels;

namespace winform原生MVVM登录界面Demo.Ioc
{
    public static class IoCContainer
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDbConnection>(sp =>
            new SqliteConnection("DataSource=./database.db")); // 设置SQLite数据库路径
            services.AddSingleton<DatabaseInitializer>();
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<LoginViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
