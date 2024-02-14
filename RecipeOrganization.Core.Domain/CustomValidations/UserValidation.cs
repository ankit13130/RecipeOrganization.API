using FluentValidation;
using RecipeOrganization.Core.Domain.RequestModels;

namespace RecipeOrganization.API.Configurations;

public class UserValidation : AbstractValidator<UserRequestModel>
{
    public UserValidation()
    {
        RuleFor(x => x.UserName).NotEmpty().NotNull().NotEqual("string").Length(5,20);
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x=>x.Password).NotEmpty().NotNull();
    }
}
