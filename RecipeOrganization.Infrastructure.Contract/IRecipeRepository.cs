using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Contract;

public interface IRecipeRepository
{
    public Task AddRecipe(Recipe recipe);
    public Task UpdateRecipe(Recipe recipe);
    public Task DeleteRecipe(long recipeId);
    public Task<Recipe> GetRecipe(long recipeId);
    public Task<ICollection<Recipe>> GetRecipes();
}
