using Microsoft.EntityFrameworkCore;
using RecipeOrganization.Infrastructure.Contract;
using RecipeOrganization.Infrastructure.Domain;
using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly RecipeContext _recipeContext;
    public ReviewRepository(RecipeContext recipeContext)
    {
        _recipeContext = recipeContext;
    }
    public async Task AddReview(Review review)
    {
        await _recipeContext.AddAsync(review);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task UpdateReview(Review review)
    {
        review.UpdatedOn = DateTime.UtcNow;
        _recipeContext.Update(review);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task DeleteReview(Review review)
    {
        review.DeletedOn = DateTime.UtcNow;
        _recipeContext.Update(review);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task<ICollection<Review>> GetAllReviews()
    {
        return await _recipeContext.Reviews.Where(x=>x.IsActive).ToListAsync();
    }

    public async Task<Review> GetReview(long reviewId)
    {
        return await _recipeContext.Reviews.Where(x => x.ReviewId == reviewId && x.IsActive).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Review>> GetReviews(long recipeId)
    {
        return await _recipeContext.Reviews.Where(x => x.RecipeId == recipeId && x.IsActive).ToListAsync();
    }
}
