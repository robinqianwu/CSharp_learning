using System.Collections.Generic;

namespace CSharp_learning.Services
{
    public class BookService
    {
        private readonly DatabaseService _databaseService;

        public BookService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void AddBook(Book book)
        {
            // Implementation for adding a book to the database
            string query = $"INSERT INTO Books (Title, Author, ISBN) VALUES ('{book.Title}', '{book.Author}', '{book.ISBN}')";
            _databaseService.ExecuteQuery(query);
        }

        public void RemoveBook(string isbn)
        {
            // Implementation for removing a book from the database
            string query = $"DELETE FROM Books WHERE ISBN = '{isbn}'";
            _databaseService.ExecuteQuery(query);
        }

        public List<Book> GetAllBooks()
        {
            // Implementation for retrieving all books from the database
            string query = "SELECT * FROM Books";
            var books = new List<Book>();
            var results = _databaseService.ExecuteQuery(query);

            foreach (var row in results)
            {
                books.Add(new Book
                {
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString(),
                    ISBN = row["ISBN"].ToString()
                });
            }

            return books;
        }
    }
}