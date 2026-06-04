using Microsoft.AspNetCore.Mvc;
using SomaAfrica.Data.Services;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // Use ControllerBase.Ok / NotFound methods

        [HttpPost]

        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            var createdTransaction = await _transactionService.AddTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = createdTransaction.TransactionId }, createdTransaction);
        }

        // Use ControllerBase.CreatedAtAction

        [HttpPost]

        [Route("mark-complete/{id}")]

        public async Task<ActionResult<Transaction>> MarkComplete(int id)
        {
            var completedTransaction = await _transactionService.MarkCompleteAsync(id);
            if (completedTransaction == null)
            {
                return NotFound();
            }
            return Ok(completedTransaction);

        }
    }
}
