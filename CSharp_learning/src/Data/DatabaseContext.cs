using System;
using System.Data.SqlClient;

namespace CSharp_learning.Data
{
    public class DatabaseContext
    {
        private string connectionString;

        public DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection Connect()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // 其他数据库相关的方法可以在这里添加
    }
}