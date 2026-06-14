using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;
using Microsoft.EntityFrameworkCore;

namespace SomaAfrica.Data.Services
{
    public class TextbookService
    {
        private readonly ITextbookRepository _textbookRepository;

        public TextbookService(ITextbookRepository textbookRepository)
        {
            _textbookRepository = textbookRepository;
        }

        public async Task<Textbook> AddTextbookAsync(Textbook textbook)
        {
            return await _textbookRepository.AddTextbookAsync(textbook);
        }

        public async Task<bool> DeleteTextbookAsync(int id)
        {
            return await _textbookRepository.DeleteTextbookAsync(id);
        }

        public async Task<List<Textbook>> GetAllTextbooksAsync()
        {
            return await _textbookRepository.GetAllTextbooksAsync();
        }

        public async Task<Textbook> GetTextbookByIdAsync(int id)
        {
            return await _textbookRepository.GetTextbookByIdAsync(id);
        }

        public async Task<Textbook> UpdateTextbookAsync(Textbook textbook)
        {
            return await _textbookRepository.UpdateTextbookAsync(textbook);
        }


    }
}
