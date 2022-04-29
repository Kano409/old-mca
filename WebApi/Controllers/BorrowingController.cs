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
    [Route("api/borrowing")]
    [ApiController]
    public class BorrowingController : Controller
    {
        private readonly IBorrowingRepository _BorrowingRepository;
        public BorrowingController(IBorrowingRepository borrowingRepository)
        {
            _BorrowingRepository = borrowingRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetBorrowings()
        {
            try
            {
                return Ok(await _BorrowingRepository.GetBorrowings());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Borrowings>> GetBorrwing(int id)
        {
            try
            {
                var result = await _BorrowingRepository.GetBorrowing(id);
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
        public async Task<ActionResult> AddBorrowing(Borrowings borrowing)
        {
            try
            {
                if (borrowing == null)
                {
                    return BadRequest();
                }
                var CreateBorrowing = await _BorrowingRepository.AddBorrowing(borrowing);
                return CreatedAtAction(nameof(AddBorrowing), new { id = CreateBorrowing.Id }, CreateBorrowing);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Borrowings>> UpdateBorrowing(int id,Borrowings borrowing)
        {
            try
            {
                if (id != borrowing.Id)
                {
                    return BadRequest("Id is not match");
                }
                var borrowingUpdated = await _BorrowingRepository.GetBorrowing(id);
                if (borrowingUpdated == null)
                {
                    return NotFound($"User {id} is not found");
                }
                var UpdatedBorrowing = await _BorrowingRepository.UpdateBorrowing(borrowing);
                return UpdatedBorrowing;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Borrowings>> DeleteBorrowing(int id)
        {
            try
            {

                var borrowingDelete = await _BorrowingRepository.GetBorrowing(id);

                if (borrowingDelete != null)
                {
                    var borrower = await _BorrowingRepository.DeleteBorrowing(id);
                    return borrower;
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpGet("{Search},Borrow")]
        public async Task<ActionResult<IEnumerable<Borrowings>>> Search(string Id)
        {
            try
            {
                var result = await _BorrowingRepository.Search(Id);
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
