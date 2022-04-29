using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    
    public class BookController : Controller
    {
        private readonly IBookRepository _BookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                return Ok(await _BookRepository.GetBooks());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Books>> GetBook(int id)
        {
            try
            {
                var result = await _BookRepository.GetBook(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddBook(Books book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest();
                }
                var CreateBook = await _BookRepository.AddBook(book);
                return CreatedAtAction(nameof(AddBook), new { id = CreateBook.Id }, CreateBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Books>> UpdateBook(int id,Books book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest("Id is not match");
                }
                var booktUpdated = await _BookRepository.GetBook(id);
                if (booktUpdated == null)
                {
                    return NotFound($"User {id} is not found");
                }
                var UpdatedStudent = await _BookRepository.UpdateBook(book);
                return UpdatedStudent;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Books>> DeleteBook(int id)
        {
            try
            {

                var bookDelete = await _BookRepository.GetBook(id);

                if (bookDelete != null)
                {
                    var book = await _BookRepository.DeleteBook(id);
                    return book;
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpGet("{Search},Book")]
        public async Task<ActionResult<IEnumerable<Books>>> Search(string Name)
        {
            try
            {
                var result = await _BookRepository.Search(Name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
    }
}
