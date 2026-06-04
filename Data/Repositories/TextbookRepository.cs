using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Repositories
{
    public class TextbookRepository : ITextbookRepository
    {
        private readonly ApplicationDbContext _context;
        public TextbookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Textbook> AddTextbookAsync(Textbook textbook)
        {
            _context.Textbooks.Add(textbook);
            await _context.SaveChangesAsync();
            return textbook;
        }

        public async Task<bool> DeleteTextbookAsync(int id)
        {
            var textbook = await _context.Textbooks.FindAsync(id);
            if (textbook == null)
            {
                return false;
            }
            _context.Textbooks.Remove(textbook);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Textbook>> GetAllTextbooksAsync()
        {
            return await _context.Textbooks.ToListAsync();
        }
        public async Task<Textbook> GetTextbookByIdAsync(int id)
        {
            return await _context.Textbooks.FindAsync(id);
        }

        public async Task<Textbook> UpdateTextbookAsync(Textbook textbook)
        {
            var existingTextbook = await _context.Textbooks.FindAsync(textbook.TextbookId);
            if (existingTextbook == null)
            {
                return null;
            }

            existingTextbook.Title = textbook.Title;
            existingTextbook.Author = textbook.Author;
            existingTextbook.ISBN = textbook.ISBN;

            _context.Textbooks.Update(existingTextbook);
            await _context.SaveChangesAsync();
            return existingTextbook;
        }
    }
}
