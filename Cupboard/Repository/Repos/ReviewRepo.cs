﻿using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;

namespace Cupboard.Repository.Repos
{
    public class ReviewRepo : IReviewRepo
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
