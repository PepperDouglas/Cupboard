using Cupboard.Helpers;
using Cupboard.Models.DTO;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;
using Cupboard.Services.Interfaces;

namespace Cupboard.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo _reviewRepo;
        private readonly IRecipeRepo _recipeRepo;

        public ReviewService(IReviewRepo reviewRepo, IRecipeRepo recipeRepo) {
            _reviewRepo = reviewRepo;
            _recipeRepo = recipeRepo;
        }

        public ResultFlag CreateReview(ReviewDTO reviewDto) {
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
            //_reviewRepo.CreateReview(review);
            //check if logged in
            if (!UserLogger.IsLogged) {
                flag.Message = "Please log in to create a review";
                return flag;    
            }

            //check if not own recipe
            var recipe = _recipeRepo.ReadRecipe(reviewDto.RecipeID);
            if (recipe.UserID == UserLogger.UserId) {
                flag.Message = "You can not review you own recipes";
                return flag;
            }

            //check if not already made review
            var allReviews = _reviewRepo.ReadAllReviews(reviewDto.RecipeID);
            foreach ( var rev in allReviews ) { 
                if (rev.UserID == UserLogger.UserId) {
                    flag.Message = "You have already posted a review for this recipe";
                    //UPDATE RECIPE
                    return flag;
                }
            }
            //domainify
            Review review = new Review(
                grade: reviewDto.Grade,
                userID: UserLogger.UserId,
                recipeID: reviewDto.RecipeID
            );
            //full send
            _reviewRepo.CreateReview(review);
            flag.Message = "Review created";
            flag.Success = true;
            return flag;
        }

        public ICollection<Review> ReadAllReviews(int recipeId) {
            return _reviewRepo.ReadAllReviews(recipeId);
            
        }

        public double GetReviewAvg(int recipeId) {
            var reviews = _reviewRepo.ReadAllReviews(recipeId);
            double avg = 0;
            foreach (var review in reviews)
            {
                avg += review.Grade;
            }
            avg /= reviews.Count;
            return avg;
        }

        public Review ReadReview(int reviewId) {
            return _reviewRepo.ReadReview(reviewId);
        }
    }
}
