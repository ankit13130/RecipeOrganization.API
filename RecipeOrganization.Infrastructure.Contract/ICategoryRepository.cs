using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Contract;

public interface ICategoryRepository
{
    public Task AddCategory(Category category);
    public Task UpdateCategory(Category category);
    public Task<Category> GetCategory(long categoryId);
    public Task<ICollection<Category>> GetCategoryies();
}
