using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SQLitePCL;

namespace winform原生MVVM登录界面Demo.Services
{
    public class DatabaseInitializer
    {

        private readonly IDbConnection _dbConnection;
        public DatabaseInitializer(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void InitializeDatabase()
        {
            Batteries.Init();

            const string createTableQuery = @"
    CREATE TABLE IF NOT EXISTS Users (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Username TEXT NOT NULL,
        Password TEXT NOT NULL
    );";


            const string insertUserQuery = @"
    INSERT INTO Users (Username, Password) VALUES (@Username, @Password);
";


            _dbConnection.Open();
            _dbConnection.Execute(createTableQuery);

            // 检查是否已有用户数据，若无则添加
            var existingUser = _dbConnection.QueryFirstOrDefault(
                "SELECT * FROM Users WHERE Username = @Username",
                new { Username = "admin" }
            ); if (existingUser == null)
            {
                _dbConnection.Execute(insertUserQuery, new { Username = "admin", Password = "password123" });
            }

            _dbConnection.Close();
        }
    }
}
