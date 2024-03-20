using Cupboard.Models.Entities;
using Cupboard.Services.Interfaces;

namespace Cupboard.Services.Services
{
    public class ReviewService : IReviewService
    {
        public void CreateReview(Review review) {
            throw new NotImplementedException();
        }

        public ICollection<Review> ReadAllReviews(int recipeId) {
            throw new NotImplementedException();
        }

        public Review ReadReview(int reviewId) {
            throw new NotImplementedException();
        }
    }
}
