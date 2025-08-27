using Microsoft.AspNetCore.Mvc;
using CSharp_learning.Models;
using CSharp_learning.Services;

namespace CSharp_learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public BookController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _databaseService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _databaseService.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpGet("available")]
        public ActionResult<IEnumerable<Book>> GetAvailableBooks()
        {
            var books = _databaseService.GetAllBooks().Where(b => b.IsAvailable);
            return Ok(books);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBook = _databaseService.CreateBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            var success = _databaseService.UpdateBook(book);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var success = _databaseService.DeleteBook(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
