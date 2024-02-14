using Microsoft.EntityFrameworkCore;
using RecipeOrganization.Infrastructure.Contract;
using RecipeOrganization.Infrastructure.Domain;
using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RecipeContext _recipeContext;
    public CategoryRepository(RecipeContext recipeContext)
    {
        _recipeContext = recipeContext;
    }
    public async Task AddCategory(Category category)
    {
        await _recipeContext.AddAsync(category);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task UpdateCategory(Category category)
    {
        category.UpdatedOn = DateTime.UtcNow;
        _recipeContext.Update(category);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task<Category> GetCategory(long categoryId)
    {
        return await _recipeContext.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Category>> GetCategoryies()
    {
        return await _recipeContext.Categories.ToListAsync();
    }
}
