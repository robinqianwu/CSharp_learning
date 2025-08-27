using MySql.Data.MySqlClient;
using System.Data;
using CSharp_learning.Models;

namespace CSharp_learning.Services
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public User? GetUserByCredentials(string username, string password)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new MySqlCommand(
                "SELECT id, username, password, role, created_at FROM users WHERE username = @username AND password = @password",
                connection);
            
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password); // 注意：实际应用中应该使用密码哈希

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Password = reader.GetString("password"), // 通常不应返回密码
                    Role = reader.GetString("role"),
                    CreatedAt = reader.GetDateTime("created_at")
                };
            }
            return null;
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using var connection = GetConnection();
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM books", connection);
            using var reader = command.ExecuteReader();
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
            return books;
        }

        public Book? GetBookById(int id)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM books WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                return new Book
                {
                    Id = reader.GetInt32("id"),
                    ISBN = reader.GetString("isbn"),
                    Title = reader.GetString("title"),
                    Author = reader.GetString("author"),
                    Publisher = reader.GetString("publisher"),
                    PublishDate = reader.GetDateTime("publish_date"),
                    Quantity = reader.GetInt32("quantity"),
                    IsAvailable = reader.GetBoolean("is_available")
                };
            }
            return null;
        }

        public Book CreateBook(Book book)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new MySqlCommand(@"
                INSERT INTO books (isbn, title, author, publisher, publish_date, quantity, is_available) 
                VALUES (@isbn, @title, @author, @publisher, @publishDate, @quantity, @isAvailable);
                SELECT LAST_INSERT_ID();", connection);

            command.Parameters.AddWithValue("@isbn", book.ISBN);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@publisher", book.Publisher);
            command.Parameters.AddWithValue("@publishDate", book.PublishDate);
            command.Parameters.AddWithValue("@quantity", book.Quantity);
            command.Parameters.AddWithValue("@isAvailable", book.IsAvailable);

            book.Id = Convert.ToInt32(command.ExecuteScalar());
            return book;
        }

        public bool UpdateBook(Book book)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new MySqlCommand(@"
                UPDATE books 
                SET isbn = @isbn, title = @title, author = @author, 
                    publisher = @publisher, publish_date = @publishDate, 
                    quantity = @quantity, is_available = @isAvailable
                WHERE id = @id", connection);

            command.Parameters.AddWithValue("@id", book.Id);
            command.Parameters.AddWithValue("@isbn", book.ISBN);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@publisher", book.Publisher);
            command.Parameters.AddWithValue("@publishDate", book.PublishDate);
            command.Parameters.AddWithValue("@quantity", book.Quantity);
            command.Parameters.AddWithValue("@isAvailable", book.IsAvailable);

            return command.ExecuteNonQuery() > 0;
        }

        public bool DeleteBook(int id)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new MySqlCommand("DELETE FROM books WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
