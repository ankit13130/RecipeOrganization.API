using Microsoft.AspNetCore.Http;

namespace RecipeOrganization.Core.Domain.RequestModels;

public record UserRequestModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public IFormFile UserImage { get; set; }
}
