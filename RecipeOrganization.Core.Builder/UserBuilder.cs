using RecipeOrganization.Core.Domain.RequestModels;
using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Core.Builder;

public class UserBuilder
{
    public static User Build(UserRequestModel userRequestModel,string hash, string salt,string fileName)
    {
        return new User(userRequestModel.UserName, hash, salt, userRequestModel.Email,fileName);
    }
}
