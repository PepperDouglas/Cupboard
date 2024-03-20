using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface IReviewRepo
    {
        void CreateReview(Review review);

        Review ReadReview(int reviewId);

        ICollection<Review> ReadAllReviews(int recipeId);
    }
}
