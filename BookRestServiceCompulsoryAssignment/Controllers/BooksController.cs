using BookLibraryCompulsoryAssignment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BookRestServiceCompulsoryAssignment.Managers;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookRestServiceCompulsoryAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookManager _manager = new BookManager();
        // GET: api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks([FromQuery] string isbn13)
        {
            var result = _manager.GetAllBooks();
            if (result.Equals(null))
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        // GET api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{string}")]
        public ActionResult<Book> GetWithISBN13(string isbn13)
        {
            Book result = _manager.GetBookByISBN13(isbn13);
            if (result.Equals(null))
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
            
        }

        // POST api/<BooksController>
        //POST adds a new item
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public ActionResult<Book>Post([FromBody] Book book)
        {
            Book newBook = _manager.AddNewBook(book);
            if (newBook.Equals(null))
            {
                return Conflict();
            }
            else
            {
                return Created(newBook.ISBN13, newBook);
            }
            
        }

        // PUT api/<BooksController>/5
        //PUT edits an existing item 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{string}")]
        public ActionResult<Book> Put(string isbn13, [FromBody] Book book)
        {
            Book updatedBook = _manager.UpdateBook(isbn13, book);
            if (updatedBook.Equals(null))
            {
                return NoContent();
            }
            else
            {
                return Ok(updatedBook);
            }
        }

        // DELETE api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{string}")]
        public ActionResult<Book> Delete(string isbn13)
        {
            Book deletedBook = _manager.DeleteBook(isbn13);
            if (deletedBook.Equals(null))
            {
                return NoContent();
            }
            else
            {
                return Ok(deletedBook);
            }

        }
    }
}
