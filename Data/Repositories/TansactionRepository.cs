using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Repositories
{
    public class TransactionRepository : ITransactionsRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Offer)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
        }
        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<Transaction> MarkCompleteAsync(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Offer)
                .FirstOrDefaultAsync(t => t.TransactionId == id);

            if (transaction == null)
            {
                return null;
            }

            transaction.TransactionDate = transaction.TransactionDate == default ? DateTime.UtcNow : transaction.TransactionDate;

            if (transaction.Offer != null && !transaction.Offer.IsAccepted)
            {
                transaction.Offer.IsAccepted = true;
                _context.Offers.Update(transaction.Offer);
            }

            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
