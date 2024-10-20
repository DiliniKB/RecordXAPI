using Microsoft.AspNetCore.Mvc;
using recordXAPI.Models;
using recordXAPI.Services;
using System.Collections.Generic;

namespace recordXAPI.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController(TransactionService transactionService) : ControllerBase
    {
        private readonly TransactionService _transactionService = transactionService;

        [HttpGet]
        public ActionResult<List<Transaction>> Get() => _transactionService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTransaction")]
        public ActionResult<Transaction> Get(string id)
        {
            var transaction = _transactionService.Get(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        [HttpPost]
        public ActionResult<Transaction> Create(Transaction transaction)
        {
            _transactionService.Create(transaction);
            return CreatedAtRoute("GetTransaction", new { id = transaction.Id.ToString() }, transaction);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Transaction transactionIn)
        {
            var transaction = _transactionService.Get(id);

            if (transaction == null)
            {
                return NotFound();
            }

            _transactionService.Update(id, transactionIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var transaction = _transactionService.Get(id);

            if (transaction == null)
            {
                return NotFound();
            }

            _transactionService.Remove(id);
            return NoContent();
        }
    }
}