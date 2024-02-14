using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Contract;

public interface IReviewRepository
{
    public Task AddReview(Review review);
    public Task UpdateReview(Review review);
    public Task DeleteReview(Review review);
    public Task<Review> GetReview(long reviewId);
    public Task<ICollection<Review>> GetReviews(long recipeId);
    public Task<ICollection<Review>> GetAllReviews();
}
