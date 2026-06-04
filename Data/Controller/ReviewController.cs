using Microsoft.AspNetCore.Mvc;
using SomaAfrica.Data.Services;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewServices _reviewServices;

        public ReviewController(ReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Review>>> GetReviewsByUserId(string userId)
        {
            var reviews = await _reviewServices.GetReviewByUserIdAsync(userId);
            return Ok(reviews);
        }

        [HttpGet("transaction/{transactionId}")]
        public async Task<ActionResult<Review>> GetReviewByTransactionId(int transactionId)
        {
            var review = await _reviewServices.GetReviewByTransactionIdAsync(transactionId);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> AddReview(Review review)
        {
            var createdReview = await _reviewServices.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReviewByTransactionId), new { transactionId = createdReview.TransactionId }, createdReview);
        }
    }
}
