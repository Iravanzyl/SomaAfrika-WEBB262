using Microsoft.AspNetCore.Mvc;
using SomaAfrica.Data.Services;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class WantedAdController : ControllerBase
    {
        private readonly WantedAdService _wantedAdService;

        public WantedAdController(WantedAdService wantedAdService)
        {
            _wantedAdService = wantedAdService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WantedAd>> GetWantedAdById(int id)
        {
            var wantedAd = await _wantedAdService.GetWantedAdByIdAsync(id);
            if (wantedAd == null)
            {
                return NotFound();
            }
            return Ok(wantedAd);
        }

        [HttpPost]
        public async Task<ActionResult<WantedAd>> AddWantedAd(WantedAd wantedAd)
        {
            var createdWantedAd = await _wantedAdService.AddWantedAdAsync(wantedAd);
            return CreatedAtAction(nameof(GetWantedAdById), new { id = createdWantedAd.WantedAdId }, createdWantedAd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WantedAd>> UpdateWantedAd(int id, WantedAd wantedAd)
        {
            if (id != wantedAd.WantedAdId)
            {
                return BadRequest();
            }

            var updatedWantedAd = await _wantedAdService.UpdateWantedAdAsync(wantedAd);
            if (updatedWantedAd == null)
            {
                return NotFound();
            }

            return Ok(updatedWantedAd);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWantedAd(int id)
        {
            var result = await _wantedAdService.DeleteWantedAdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}