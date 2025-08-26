using MySql.Data.MySqlClient;
using System;

namespace CSharp_learning.Services
{
    public class DatabaseService
    {
        private string connectionString;

        public DatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MySqlConnection Connect()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("数据库连接失败: " + ex.Message);
                return null;
            }
        }

        public void ExecuteQuery(string query)
        {
            using (var connection = Connect())
            {
                if (connection == null) return;

                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}