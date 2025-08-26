using MySql.Data.MySqlClient;
using System.Data;
using CSharp_learning.Models;

namespace CSharp_learning.Services
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService()
        {
            // user and password are hardcoded here!!
            connectionString = "Server=localhost;Database=library_db;Uid=eysler;Pwd=start;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool ValidateUser(string username, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password); // 注意：实际应用中应该使用密码哈希

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM books", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32("id"),
                            ISBN = reader.GetString("isbn"),
                            Title = reader.GetString("title"),
                            Author = reader.GetString("author"),
                            Publisher = reader.GetString("publisher"),
                            PublishDate = reader.GetDateTime("publish_date"),
                            Quantity = reader.GetInt32("quantity"),
                            IsAvailable = reader.GetBoolean("is_available")
                        });
                    }
                }
            }
            return books;
        }
    }
}
