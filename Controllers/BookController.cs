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
        public IActionResult GetAllBooks()
        {
            var books = _databaseService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _databaseService.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
    }
}
