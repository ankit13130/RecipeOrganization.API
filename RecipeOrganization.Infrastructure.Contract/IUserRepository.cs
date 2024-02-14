using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Infrastructure.Contract;

public interface IUserRepository
{
    public Task AddUser(User user);
    public Task UpdateUser(User user,long sid);
    public Task DeleteUser(User user, long sid);
    public Task<User> GetUser(long userId);
    public Task<User> GetUser(string email);
    public Task<ICollection<User>> GetUsers();
}
