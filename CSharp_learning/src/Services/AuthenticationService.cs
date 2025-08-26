using System;
using System.Data.SqlClient;

namespace CSharp_learning.Services
{
    public class AuthenticationService
    {
        private readonly DatabaseService _databaseService;

        public AuthenticationService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public bool Login(string username, string password)
        {
            // 这里可以添加逻辑来验证用户凭据
            // 例如，查询数据库以检查用户名和密码是否匹配
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
            using (var connection = _databaseService.Connect())
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    int result = (int)command.ExecuteScalar();
                    return result > 0;
                }
            }
        }

        public void Logout()
        {
            // 这里可以添加注销逻辑
            // 例如，清除用户会话信息
        }
    }
}