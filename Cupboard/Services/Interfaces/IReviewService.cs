using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{
    public interface IReviewService
    {
        void CreateReview(Review review);

        Review ReadReview(int reviewId);

        ICollection<Review> ReadAllReviews(int recipeId);
    }
}
