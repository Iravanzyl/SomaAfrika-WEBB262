using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Services
{
    public class TransactionService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        public TransactionService(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _transactionsRepository.GetTransactionByIdAsync(id);
        }
        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            return await _transactionsRepository.AddTransactionAsync(transaction);
        }
        public async Task<Transaction> MarkCompleteAsync(int id)
        {
            return await _transactionsRepository.MarkCompleteAsync(id);
        }
    }
}
