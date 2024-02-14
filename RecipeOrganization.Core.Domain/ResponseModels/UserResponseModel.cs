namespace RecipeOrganization.Core.Domain.ResponseModels;

public record UserResponseModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string UserImage { get; set; }
}
