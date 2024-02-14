using Microsoft.EntityFrameworkCore;
using RecipeOrganization.Infrastructure.Contract;
using RecipeOrganization.Infrastructure.Domain;
using RecipeOrganization.Infrastructure.Domain.Entities;
using System.Security.Claims;

namespace RecipeOrganization.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RecipeContext _recipeContext;
    public UserRepository(RecipeContext recipeContext)
    {
        _recipeContext = recipeContext;
    }
    public async Task AddUser(User user)
    {
        await _recipeContext.AddAsync(user);
        await _recipeContext.SaveChangesAsync();
        user.CreatedBy = user.UserId;
        _recipeContext.Update(user);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User user, long sid)
    {
        user.UpdatedBy = sid;
        user.UpdatedOn = DateTime.UtcNow;
        _recipeContext.Update(user);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task DeleteUser(User user,long sid)
    {
        user.DeletedBy = sid;
        user.IsActive = false;
        user.DeletedOn = DateTime.UtcNow;
        _recipeContext.Update(user);
        await _recipeContext.SaveChangesAsync();
    }

    public async Task<User> GetUser(long userId)
    {
        return await _recipeContext.Users.Where(x => x.UserId == userId && x.IsActive).Include(x=>x.Recipes).Where(x=>x.UserId == userId).FirstOrDefaultAsync();
    }
    
    public async Task<User> GetUser(string email)
    {
        return await _recipeContext.Users.Where(x => x.Email == email && x.IsActive).FirstOrDefaultAsync();
    }

    public async Task<ICollection<User>> GetUsers()
    {
        return await _recipeContext.Users.Where(x => x.IsActive).ToListAsync();
    }
}
