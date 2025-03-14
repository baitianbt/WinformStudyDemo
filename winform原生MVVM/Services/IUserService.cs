using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using winform原生MVVM登录界面Demo.Models;

namespace winform原生MVVM登录界面Demo.Services
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
    }

    public class UserService : IUserService
    {
        private readonly IDbConnection _dbConnection;

        public UserService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public User GetUserByUsername(string username)
        {
            string sql = "SELECT * FROM Users WHERE Username = @Username";
            return _dbConnection.QuerySingleOrDefault<User>(sql, new { Username = username });
        }
    }
}
