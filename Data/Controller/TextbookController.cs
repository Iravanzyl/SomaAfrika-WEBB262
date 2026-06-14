using Microsoft.AspNetCore.Mvc;
using SomaAfrica.Data.Services;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextbookController : ControllerBase
    {
        private readonly TextbookService _textbookService;

        public TextbookController(TextbookService textbookService)
        {
            _textbookService = textbookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Textbook>>> GetAllTextbooks()
        {
            var textbooks = await _textbookService.GetAllTextbooksAsync();
            return Ok(textbooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Textbook>> GetTextbookById(int id)
        {
            var textbook = await _textbookService.GetTextbookByIdAsync(id);
            if (textbook == null)
            {
                return NotFound();
            }
            return Ok(textbook);
        }

        [HttpPost]
        public async Task<ActionResult<Textbook>> CreateTextbook(Textbook textbook)
        {
            var createdTextbook = await _textbookService.AddTextbookAsync(textbook);
            return CreatedAtAction(nameof(GetTextbookById), new { id = createdTextbook.TextbookId }, createdTextbook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTextbook(int id, Textbook textbook)
        {
            if (id != textbook.TextbookId)
            {
                return BadRequest();
            }

            var updatedTextbook = await _textbookService.UpdateTextbookAsync(textbook);
            if (updatedTextbook == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTextbook(int id)
        {
            var deletedTextbook = await _textbookService.DeleteTextbookAsync(id);
            if (deletedTextbook == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
