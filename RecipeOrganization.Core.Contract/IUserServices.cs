using RecipeOrganization.Core.Domain.RequestModels;
using RecipeOrganization.Core.Domain.ResponseModels;

namespace RecipeOrganization.Core.Contract;

public interface IUserServices
{
    //public Task AddUser(UserRequestModel userRequestModel);
    public Task UpdateUser(UserRequestModel userRequestModel,long sid);
    public Task DeleteUser(long userId, long sid);
    public Task<UserResponseModel> GetUser(long userId);
    public Task<ICollection<UserResponseModel>> GetUsers();
}
