using Cupboard.Helpers;
using Cupboard.Models.DTO;
using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{
    public interface IReviewService
    {
        ResultFlag CreateReview(ReviewDTO reviewDto);

        Review ReadReview(int reviewId);

        ICollection<Review> ReadAllReviews(int recipeId);

        double GetReviewAvg(int recipeId);
    }
}
