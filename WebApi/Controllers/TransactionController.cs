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
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _TransactionRepository;
        public TransactionController(ITransactionRepository transactionRepository)
        {
            _TransactionRepository = transactionRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetTransactions()
        {
            try
            {
                return Ok(await _TransactionRepository.GetTransactions());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transactions>> GetTransaction(int id)
        {
            try
            {
                var result = await _TransactionRepository.GetTransaction(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddTransaction(Transactions transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return BadRequest();
                }
                var CreateTransaction = await _TransactionRepository.AddTransaction(transaction);
                return CreatedAtAction(nameof(GetTransaction), new { id = CreateTransaction.Id }, CreateTransaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Transactions>> UpdateTransaction(int id,Transactions transaction)
        {
            try
            {
                if (id != transaction.Id)
                {
                    return BadRequest("Id is not match");
                }
                var transactionUpdated = await _TransactionRepository.GetTransaction(id);
                if (transactionUpdated == null)
                {
                    return NotFound($"User {id} is not found");
                }
                var UpdatedTransaction = await _TransactionRepository.UpdateTransaction(transaction);
                return UpdatedTransaction;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Transactions>> DeleteTransaction(int id)
        {
            try
            {

                var transactionDelete = await _TransactionRepository.GetTransaction(id);

                if (transactionDelete != null)
                {
                    var trans = await _TransactionRepository.DeleteTransaction(id);
                    return trans;
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpGet("{Search},Trans")]
        public async Task<ActionResult<IEnumerable<Transactions>>> Search(string status)
        {
            try
            {
                var result = await _TransactionRepository.Search(status);
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
