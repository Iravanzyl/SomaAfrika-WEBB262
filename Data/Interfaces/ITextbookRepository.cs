using SomaAfrica.Models;

using SomaAfrica.Models;

namespace SomaAfrica.Data.Interfaces
{
    public interface ITextbookRepository
    {
        Task<List<Textbook>> GetAllTextbooksAsync();
        Task<Textbook> GetTextbookByIdAsync(int id);
        Task<Textbook> AddTextbookAsync(Textbook textbook);
        Task<Textbook> UpdateTextbookAsync(Textbook textbook);
        Task<bool> DeleteTextbookAsync(int id);
    }
}
