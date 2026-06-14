using SomaAfrica.Models;


namespace SomaAfrica.Data.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<Transaction> MarkCompleteAsync(int id);
    }
}
