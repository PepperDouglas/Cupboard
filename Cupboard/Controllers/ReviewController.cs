using Cupboard.Models.DTO;
using Cupboard.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cupboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService) {
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        //read1
        public IActionResult GetReview(int id) {
            try {
                var review = _reviewService.ReadReview(id);
                return Ok(review);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reviews-for-recipe/{id}")]
        //readall
        public IActionResult GetRecipeReviews(int id) {
            try {
                var reviews = _reviewService.ReadAllReviews(id);
                return Ok(reviews);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        //create
        public IActionResult CreateReview(ReviewDTO reviewDTO) {
            try {
                var status = _reviewService.CreateReview(reviewDTO);
                if (!status.Success) {
                    return BadRequest(status.Message);
                }
                return Ok("Review created");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
