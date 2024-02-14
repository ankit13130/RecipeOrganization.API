using RecipeOrganization.Core.Domain.RequestModels;

namespace RecipeOrganization.Core.Contract;

public interface IValidationServices
{
    public Task<string> ValidateLoginAsync(LoginRequestModel loginRequestModel);
    public Task ValidateSignupAsync(UserRequestModel studentRequestModel);
}
